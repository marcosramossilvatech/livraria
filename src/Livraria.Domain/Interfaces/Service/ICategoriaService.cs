using Livraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Domain.Interfaces.Service
{
    public interface ICategoriaService : IDisposable
    {
        Task<IEnumerable<Categoria>> GetAll();
        Task<Categoria> GetById(int id);
        Task<Categoria> Add(Categoria category);
        Task<Categoria> Update(Categoria category);
        Task<bool> Remove(Categoria category);
        Task<IEnumerable<Categoria>> Search(string categoryName);
    }
}
