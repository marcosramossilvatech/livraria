using Livraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Domain.Interfaces.Service
{
    public interface ILivroService : IDisposable
    {
        Task<IEnumerable<Livro>> GetAll();
        Task<Livro> GetById(int id);
        Task<Livro> Add(Livro book);
        Task<Livro> Update(Livro book);
        Task<bool> Remove(Livro book);
        Task<IEnumerable<Livro>> GetBooksByCategory(int categoryId);
        Task<IEnumerable<Livro>> Search(string bookName);
        Task<IEnumerable<Livro>> SearchBookWithCategory(string searchedValue);
    }
}
