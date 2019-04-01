using System;
using System.Collections.Generic;

namespace ProjectAPI.Models
{
    public partial class BookCopy
    {
        public int CopyCount { get; set; }
        public string Isbn { get; set; }
        public string StudentId { get; set; }

        public Book IsbnNavigation { get; set; }
        public Student Student { get; set; }
    }
}
