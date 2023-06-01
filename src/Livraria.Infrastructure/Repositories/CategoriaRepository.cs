using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using Livraria.Infrastructure.Context;

namespace Livraria.Infrastructure.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(LivrariaDbContext context) : base(context) { }
    }
}
