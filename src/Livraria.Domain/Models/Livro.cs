﻿using System;

namespace Livraria.Domain.Models
{
    public class Livro : Entity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }

        public Categoria Category { get; set; }
    }
}
