using System;
using System.Collections.Generic;

namespace ProjectAPI.Models
{
    public partial class Book
    {
        public Book()
        {
            BookCopy = new HashSet<BookCopy>();
        }

        public string Isbn { get; set; }
        public string Title { get; set; }
        public int YearPublished { get; set; }
        public int AuthorId { get; set; }

        public Author Author { get; set; }
        public ICollection<BookCopy> BookCopy { get; set; }
    }
}
