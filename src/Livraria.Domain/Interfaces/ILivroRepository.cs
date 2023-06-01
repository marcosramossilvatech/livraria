using Livraria.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Domain.Interfaces
{
    public interface ILivroRepository : IRepository<Livro>
    {
        new Task<List<Livro>> GetAll();
        new Task<Livro> GetById(int id);
        Task<IEnumerable<Livro>> GetBooksByCategory(int categoryId);
        Task<IEnumerable<Livro>> SearchBookWithCategory(string searchedValue);
    }
}
