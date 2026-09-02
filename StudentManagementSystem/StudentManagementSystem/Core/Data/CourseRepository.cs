using StudentManagementSystem.Core.Exceptions;
using StudentManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StudentManagementSystem.Core.Data
{
    public class CourseRepository
    {
        /// <summary>
        /// Retrieves all active courses from the database.
        /// </summary>
        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>();
            string query = @"SELECT CourseID, CourseCode, CourseName, Credits, Department, AssignedTeacherID, IsActive 
                             FROM Courses 
                             WHERE IsActive = 1 
                             ORDER BY CourseCode ASC";

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                foreach (DataRow row in dt.Rows)
                {
                    courses.Add(MapRowToCourse(row));
                }
                return courses;
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error retrieving course records from database.", ex);
            }
        }

        /// <summary>
        /// Retrieves a course by its CourseID.
        /// </summary>
        public Course GetCourseById(int courseId)
        {
            string query = @"SELECT CourseID, CourseCode, CourseName, Credits, Department, AssignedTeacherID, IsActive 
                             FROM Courses 
                             WHERE CourseID = @CourseID AND IsActive = 1";

            SqlParameter[] parameters = {
                new SqlParameter("@CourseID", courseId)
            };

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count == 0)
                    throw new CourseNotFoundException($"Course with ID {courseId} was not found.");

                return MapRowToCourse(dt.Rows[0]);
            }
            catch (SqlException ex)
            {
                throw new DatabaseException($"Error retrieving course ID {courseId}.", ex);
            }
        }

        /// <summary>
        /// Inserts a new course into the database.
        /// </summary>
        public void AddCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            course.Validate();

            if (CourseCodeExists(course.CourseCode))
                throw new ValidationException($"Course code '{course.CourseCode}' already exists.");

            string query = @"INSERT INTO Courses (CourseCode, CourseName, Credits, Department, AssignedTeacherID, IsActive)
                             VALUES (@CourseCode, @CourseName, @Credits, @Department, @AssignedTeacherID, 1)";

            SqlParameter[] parameters = {
                new SqlParameter("@CourseCode", course.CourseCode.Trim().ToUpper()),
                new SqlParameter("@CourseName", course.CourseName.Trim()),
                new SqlParameter("@Credits", course.Credits),
                new SqlParameter("@Department", (object)course.Department ?? DBNull.Value),
                new SqlParameter("@AssignedTeacherID", (object)course.AssignedTeacherID ?? DBNull.Value)
            };

            try
            {
                DatabaseHelper.ExecuteNonQuery(query, parameters);
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Failed to add new course to the database.", ex);
            }
        }

        /// <summary>
        /// Updates an existing course in the database.
        /// </summary>
        public void UpdateCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            course.Validate();

            if (CourseCodeExists(course.CourseCode, course.CourseID))
                throw new ValidationException($"Course code '{course.CourseCode}' is already in use by another course.");

            string query = @"UPDATE Courses 
                             SET CourseCode = @CourseCode,
                                 CourseName = @CourseName,
                                 Credits = @Credits,
                                 Department = @Department,
                                 AssignedTeacherID = @AssignedTeacherID
                             WHERE CourseID = @CourseID AND IsActive = 1";

            SqlParameter[] parameters = {
                new SqlParameter("@CourseID", course.CourseID),
                new SqlParameter("@CourseCode", course.CourseCode.Trim().ToUpper()),
                new SqlParameter("@CourseName", course.CourseName.Trim()),
                new SqlParameter("@Credits", course.Credits),
                new SqlParameter("@Department", (object)course.Department ?? DBNull.Value),
                new SqlParameter("@AssignedTeacherID", (object)course.AssignedTeacherID ?? DBNull.Value)
            };

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rows == 0)
                    throw new CourseNotFoundException($"Unable to update. Course ID {course.CourseID} not found.");
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Failed to update course in the database.", ex);
            }
        }

        /// <summary>
        /// Soft-deletes a course (sets IsActive = 0).
        /// </summary>
        public void DeleteCourse(int courseId)
        {
            string query = @"UPDATE Courses SET IsActive = 0 WHERE CourseID = @CourseID";

            SqlParameter[] parameters = {
                new SqlParameter("@CourseID", courseId)
            };

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rows == 0)
                    throw new CourseNotFoundException($"Unable to delete. Course ID {courseId} not found.");
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Failed to delete course from database.", ex);
            }
        }

        /// <summary>
        /// Checks if a course code already exists.
        /// </summary>
        public bool CourseCodeExists(string courseCode, int excludeCourseId = 0)
        {
            string query = @"SELECT COUNT(1) FROM Courses 
                             WHERE CourseCode = @CourseCode AND CourseID <> @ExcludeCourseID AND IsActive = 1";

            SqlParameter[] parameters = {
                new SqlParameter("@CourseCode", courseCode.Trim()),
                new SqlParameter("@ExcludeCourseID", excludeCourseId)
            };

            try
            {
                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error checking course code uniqueness.", ex);
            }
        }

        private Course MapRowToCourse(DataRow row)
        {
            return new Course
            {
                CourseID = Convert.ToInt32(row["CourseID"]),
                CourseCode = row["CourseCode"].ToString(),
                CourseName = row["CourseName"].ToString(),
                Credits = Convert.ToInt32(row["Credits"]),
                Department = row["Department"] != DBNull.Value ? row["Department"].ToString() : string.Empty,
                AssignedTeacherID = row["AssignedTeacherID"] != DBNull.Value ? (int?)Convert.ToInt32(row["AssignedTeacherID"]) : null,
                IsActive = Convert.ToBoolean(row["IsActive"])
            };
        }
    }
}
