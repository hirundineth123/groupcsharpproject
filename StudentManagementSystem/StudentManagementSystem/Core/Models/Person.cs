using StudentManagementSystem.Core.Exceptions;
using System;

namespace StudentManagementSystem.Core.Models
{
    public abstract class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public string FullName => $"{FirstName} {LastName}".Trim();

        protected Person() { }

        protected Person(string firstName, string lastName, string email, string phone, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public virtual void Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new ValidationException("First name is required.");

            if (string.IsNullOrWhiteSpace(LastName))
                throw new ValidationException("Last name is required.");

            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
                throw new ValidationException("A valid email address is required.");
        }
    }
}
