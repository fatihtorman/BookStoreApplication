using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Isbn
    {
        public int Id { get; set; }
        public int IsbnNo { get; set; }

        public Book book { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
