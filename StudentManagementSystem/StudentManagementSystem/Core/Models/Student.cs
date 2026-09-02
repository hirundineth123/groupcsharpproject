using StudentManagementSystem.Core.Exceptions;
using System;

namespace StudentManagementSystem.Core.Models
{
    public class Student : Person
    {
        public int StudentID { get; set; }
        public string RegNumber { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now.AddYears(-20);
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public Student() { }

        public Student(string regNumber, string firstName, string lastName, string email, string phone, string address, DateTime dateOfBirth)
            : base(firstName, lastName, email, phone, address)
        {
            RegNumber = regNumber;
            DateOfBirth = dateOfBirth;
            EnrollmentDate = DateTime.Now;
            IsActive = true;
        }

        public override void Validate()
        {
            base.Validate();

            if (string.IsNullOrWhiteSpace(RegNumber))
                throw new ValidationException("Registration number is required.");

            if (DateOfBirth >= DateTime.Now)
                throw new ValidationException("Date of birth must be in the past.");
        }
    }
}
