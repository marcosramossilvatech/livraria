using System.Collections.Generic;

namespace Livraria.Domain.Models
{
    public class Categoria : Entity
    {
        public string Name { get; set; }

        public IEnumerable<Livro> Books { get; set; }
    }
}
