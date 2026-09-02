using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message, Exception inner) : base(message, inner) { }
    }

    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message) : base(message) { }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }

    public class CourseNotFoundException : Exception
    {
        public CourseNotFoundException(string message) : base(message) { }
    }
}
