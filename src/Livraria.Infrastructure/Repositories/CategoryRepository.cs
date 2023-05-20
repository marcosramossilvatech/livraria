using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using Livraria.Infrastructure.Context;

namespace Livraria.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(LivrariaDbContext context) : base(context) { }
    }
}
