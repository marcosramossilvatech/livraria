﻿using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using Livraria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Infrastructure.Repositories
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(LivrariaDbContext context) : base(context) { }

        public override async Task<List<Livro>> GetAll()
        {
            return await Db.Books.AsNoTracking().Include(b => b.Category)
                .OrderBy(b => b.Name)
                .ToListAsync();
        }

        public override async Task<Livro> GetById(int id)
        {
            return await Db.Books.AsNoTracking().Include(b => b.Category)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Livro>> GetBooksByCategory(int categoryId)
        {
            return await Search(b => b.CategoryId == categoryId);
        }

        public async Task<IEnumerable<Livro>> SearchBookWithCategory(string searchedValue)
        {
            return await Db.Books.AsNoTracking()
                .Include(b => b.Category)
                .Where(b => b.Name.Contains(searchedValue) ||
                            b.Author.Contains(searchedValue) ||
                            b.Description.Contains(searchedValue) ||
                            b.Category.Name.Contains(searchedValue))
                .ToListAsync();
        }
    }
}
