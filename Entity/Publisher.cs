using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Publisher
    {
        public int Id { get; set; }

        public string PublisherName { get; set; }

        public Book Book { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
