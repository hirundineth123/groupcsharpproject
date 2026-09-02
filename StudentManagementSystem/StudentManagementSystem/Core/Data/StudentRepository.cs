using StudentManagementSystem.Core.Exceptions;
using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StudentManagementSystem.Core.Data
{
    public class StudentRepository
    {
        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();
            string query = @"SELECT StudentID, RegNumber, FirstName, LastName, Email, Phone, Address, DateOfBirth, EnrollmentDate, IsActive 
                             FROM Students 
                             WHERE IsActive = 1 
                             ORDER BY RegNumber ASC";

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                foreach (DataRow row in dt.Rows)
                {
                    students.Add(MapRowToStudent(row));
                }
                return students;
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error retrieving student records from database.", ex);
            }
        }

        public Student GetStudentById(int studentId)
        {
            string query = @"SELECT StudentID, RegNumber, FirstName, LastName, Email, Phone, Address, DateOfBirth, EnrollmentDate, IsActive 
                             FROM Students 
                             WHERE StudentID = @StudentID AND IsActive = 1";

            SqlParameter[] parameters = {
                new SqlParameter("@StudentID", studentId)
            };

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count == 0)
                    throw new ValidationException($"Student with ID {studentId} was not found.");

                return MapRowToStudent(dt.Rows[0]);
            }
            catch (SqlException ex)
            {
                throw new DatabaseException($"Error retrieving student ID {studentId}.", ex);
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            student.Validate();

            if (RegNumberExists(student.RegNumber))
                throw new ValidationException($"Student registration number '{student.RegNumber}' already exists.");

            string query = @"INSERT INTO Students (RegNumber, FirstName, LastName, Email, Phone, Address, DateOfBirth, EnrollmentDate, IsActive)
                             VALUES (@RegNumber, @FirstName, @LastName, @Email, @Phone, @Address, @DateOfBirth, @EnrollmentDate, 1)";

            SqlParameter[] parameters = {
                new SqlParameter("@RegNumber", student.RegNumber.Trim().ToUpper()),
                new SqlParameter("@FirstName", student.FirstName.Trim()),
                new SqlParameter("@LastName", student.LastName.Trim()),
                new SqlParameter("@Email", student.Email.Trim()),
                new SqlParameter("@Phone", (object)student.Phone ?? DBNull.Value),
                new SqlParameter("@Address", (object)student.Address ?? DBNull.Value),
                new SqlParameter("@DateOfBirth", student.DateOfBirth),
                new SqlParameter("@EnrollmentDate", student.EnrollmentDate)
            };

            try
            {
                DatabaseHelper.ExecuteNonQuery(query, parameters);
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Failed to add new student record to the database.", ex);
            }
        }

        public void UpdateStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            student.Validate();

            if (RegNumberExists(student.RegNumber, student.StudentID))
                throw new ValidationException($"Registration number '{student.RegNumber}' is already in use by another student.");

            string query = @"UPDATE Students 
                             SET RegNumber = @RegNumber,
                                 FirstName = @FirstName,
                                 LastName = @LastName,
                                 Email = @Email,
                                 Phone = @Phone,
                                 Address = @Address,
                                 DateOfBirth = @DateOfBirth
                             WHERE StudentID = @StudentID AND IsActive = 1";

            SqlParameter[] parameters = {
                new SqlParameter("@StudentID", student.StudentID),
                new SqlParameter("@RegNumber", student.RegNumber.Trim().ToUpper()),
                new SqlParameter("@FirstName", student.FirstName.Trim()),
                new SqlParameter("@LastName", student.LastName.Trim()),
                new SqlParameter("@Email", student.Email.Trim()),
                new SqlParameter("@Phone", (object)student.Phone ?? DBNull.Value),
                new SqlParameter("@Address", (object)student.Address ?? DBNull.Value),
                new SqlParameter("@DateOfBirth", student.DateOfBirth)
            };

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rows == 0)
                    throw new ValidationException($"Unable to update. Student ID {student.StudentID} not found.");
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Failed to update student record in database.", ex);
            }
        }

        public void DeleteStudent(int studentId)
        {
            string query = @"UPDATE Students SET IsActive = 0 WHERE StudentID = @StudentID";

            SqlParameter[] parameters = {
                new SqlParameter("@StudentID", studentId)
            };

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rows == 0)
                    throw new ValidationException($"Unable to delete. Student ID {studentId} not found.");
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Failed to delete student record from database.", ex);
            }
        }

        public bool RegNumberExists(string regNumber, int excludeStudentId = 0)
        {
            string query = @"SELECT COUNT(1) FROM Students 
                             WHERE RegNumber = @RegNumber AND StudentID <> @ExcludeStudentID AND IsActive = 1";

            SqlParameter[] parameters = {
                new SqlParameter("@RegNumber", regNumber.Trim()),
                new SqlParameter("@ExcludeStudentID", excludeStudentId)
            };

            try
            {
                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error checking registration number uniqueness.", ex);
            }
        }

        private Student MapRowToStudent(DataRow row)
        {
            return new Student
            {
                StudentID = Convert.ToInt32(row["StudentID"]),
                PersonID = Convert.ToInt32(row["StudentID"]),
                RegNumber = row["RegNumber"].ToString(),
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Email = row["Email"].ToString(),
                Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : string.Empty,
                Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : string.Empty,
                DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                EnrollmentDate = Convert.ToDateTime(row["EnrollmentDate"]),
                IsActive = Convert.ToBoolean(row["IsActive"])
            };
        }
    }
}
