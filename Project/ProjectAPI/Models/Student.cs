using System;
using System.Collections.Generic;

namespace ProjectAPI.Models
{
    public partial class Student
    {
        public Student()
        {
            BookCopy = new HashSet<BookCopy>();
        }

        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public ICollection<BookCopy> BookCopy { get; set; }
    }
}
