
using System;

namespace Entity
{

    public class Book
    {

        public int Id { get; set; }

        public string BookName { get; set; }

        public string Format { get; set; }
        public string Preface { get; set; }
        public int Quantity { get; set; }
        public int Version { get; set; }
        public int WarehouseLocation { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Isbn Isbn { get; set; }
        public Publisher Publisher { get; set; }

        public Author Author { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
