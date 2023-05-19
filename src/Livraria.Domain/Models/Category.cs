﻿using System.Collections.Generic;

namespace Livraria.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}