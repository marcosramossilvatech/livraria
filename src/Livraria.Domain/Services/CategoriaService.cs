using Livraria.Domain.Interfaces.Service;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Livraria.Domain.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoryRepository;
        private readonly ILivroService _bookService;

        public CategoriaService(ICategoriaRepository categoryRepository, ILivroService bookService)
        {
            _categoryRepository = categoryRepository;
            _bookService = bookService;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Categoria> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<Categoria> Add(Categoria category)
        {
            if (_categoryRepository.Search(c => c.Name == category.Name).Result.Any())
                return null;

            await _categoryRepository.Add(category);
            return category;
        }

        public async Task<Categoria> Update(Categoria category)
        {
            if (_categoryRepository.Search(c => c.Name == category.Name && c.Id != category.Id).Result.Any())
                return null;

            await _categoryRepository.Update(category);
            return category;
        }

        public async Task<bool> Remove(Categoria category)
        {
            var books = await _bookService.GetBooksByCategory(category.Id);
            if (books.Any()) return false;

            await _categoryRepository.Remove(category);
            return true;
        }

        public async Task<IEnumerable<Categoria>> Search(string categoryName)
        {
            return await _categoryRepository.Search(c => c.Name.Contains(categoryName));
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }
    }
}
