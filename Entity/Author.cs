using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }

        public string Nation { get; set; }

        public string Country { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
