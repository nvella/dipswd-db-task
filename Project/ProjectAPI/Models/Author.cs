using System;
using System.Collections.Generic;

namespace ProjectAPI.Models
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tfn { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}
