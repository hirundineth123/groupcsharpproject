using StudentManagementSystem.Core.Exceptions;
using System;

namespace StudentManagementSystem.Core.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public string Department { get; set; }
        public int? AssignedTeacherID { get; set; }
        public bool IsActive { get; set; } = true;

        public Course() { }

        public Course(string courseCode, string courseName, int credits, string department = "", int? assignedTeacherID = null)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            Credits = credits;
            Department = department;
            AssignedTeacherID = assignedTeacherID;
            IsActive = true;
        }

        /// <summary>
        /// Validates domain requirements for a course.
        /// Throws ValidationException if validation fails.
        /// </summary>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(CourseCode))
                throw new ValidationException("Course code cannot be empty.");

            if (string.IsNullOrWhiteSpace(CourseName))
                throw new ValidationException("Course name cannot be empty.");

            if (Credits <= 0 || Credits > 10)
                throw new ValidationException("Credits must be a positive integer between 1 and 10.");
        }
    }
}
