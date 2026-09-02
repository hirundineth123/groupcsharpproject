using StudentManagementSystem.Core.Exceptions;
using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StudentManagementSystem.Core.Data
{
    public class EnrollmentRepository
    {
        /// <summary>
        /// Enrolls a student into a course.
        /// </summary>
        public void EnrollStudent(int studentId, int courseId)
        {
            if (IsStudentEnrolled(studentId, courseId))
                throw new ValidationException("Student is already enrolled in this course.");

            string query = @"INSERT INTO StudentCourses (StudentID, CourseID, EnrollmentDate, Status)
                             VALUES (@StudentID, @CourseID, GETDATE(), 'Enrolled')";

            SqlParameter[] parameters = {
                new SqlParameter("@StudentID", studentId),
                new SqlParameter("@CourseID", courseId)
            };

            try
            {
                DatabaseHelper.ExecuteNonQuery(query, parameters);
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Failed to enroll student into course.", ex);
            }
        }

        /// <summary>
        /// Drops or un-enrolls a student from a course.
        /// </summary>
        public void UnenrollStudent(int studentId, int courseId)
        {
            string query = @"DELETE FROM StudentCourses WHERE StudentID = @StudentID AND CourseID = @CourseID";

            SqlParameter[] parameters = {
                new SqlParameter("@StudentID", studentId),
                new SqlParameter("@CourseID", courseId)
            };

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rows == 0)
                    throw new ValidationException("Enrollment record not found.");
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Failed to un-enroll student from course.", ex);
            }
        }

        /// <summary>
        /// Checks if a student is already enrolled in a specific course.
        /// </summary>
        public bool IsStudentEnrolled(int studentId, int courseId)
        {
            string query = @"SELECT COUNT(1) FROM StudentCourses WHERE StudentID = @StudentID AND CourseID = @CourseID";

            SqlParameter[] parameters = {
                new SqlParameter("@StudentID", studentId),
                new SqlParameter("@CourseID", courseId)
            };

            try
            {
                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error checking enrollment status.", ex);
            }
        }

        /// <summary>
        /// Retrieves all enrollments joining Students and Courses tables.
        /// </summary>
        public DataTable GetAllEnrollmentsView()
        {
            string query = @"SELECT sc.EnrollmentID, 
                                    s.StudentID, 
                                    s.RegNumber, 
                                    (s.FirstName + ' ' + s.LastName) AS StudentName,
                                    c.CourseID, 
                                    c.CourseCode, 
                                    c.CourseName, 
                                    sc.EnrollmentDate, 
                                    sc.Status
                             FROM StudentCourses sc
                             JOIN Students s ON sc.StudentID = s.StudentID
                             JOIN Courses c ON sc.CourseID = c.CourseID
                             WHERE s.IsActive = 1 AND c.IsActive = 1
                             ORDER BY sc.EnrollmentDate DESC";

            try
            {
                return DatabaseHelper.ExecuteQuery(query);
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error retrieving enrollment records.", ex);
            }
        }
    }
}
