using Livraria.Domain.Interfaces;
using Livraria.Domain.Interfaces.Service;
using Livraria.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Domain.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _bookRepository;

        public LivroService(ILivroRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Livro>> GetAll()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Livro> GetById(int id)
        {
            return await _bookRepository.GetById(id);
        }

        public async Task<Livro> Add(Livro book)
        {
            if (_bookRepository.Search(b => b.Name == book.Name).Result.Any())
                return null;

            await _bookRepository.Add(book);
            return book;
        }

        public async Task<Livro> Update(Livro book)
        {
            if (_bookRepository.Search(b => b.Name == book.Name && b.Id != book.Id).Result.Any())
                return null;

            await _bookRepository.Update(book);
            return book;
        }

        public async Task<bool> Remove(Livro book)
        {
            await _bookRepository.Remove(book);
            return true;
        }

        public async Task<IEnumerable<Livro>> GetBooksByCategory(int categoryId)
        {
            return await _bookRepository.GetBooksByCategory(categoryId);
        }

        public async Task<IEnumerable<Livro>> Search(string bookName)
        {
            return await _bookRepository.Search(c => c.Name.Contains(bookName));
        }

        public async Task<IEnumerable<Livro>> SearchBookWithCategory(string searchedValue)
        {
            return await _bookRepository.SearchBookWithCategory(searchedValue);
        }

        public void Dispose()
        {
            _bookRepository?.Dispose();
        }
    }
}
