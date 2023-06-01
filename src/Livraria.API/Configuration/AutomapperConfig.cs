using AutoMapper;
using Livraria.API.Dtos.Book;
using Livraria.API.Dtos.Category;
using Livraria.Domain.Models;

namespace Livraria.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Categoria, CategoriaAddDto>().ReverseMap();
            CreateMap<Categoria, CategoriaEditDto>().ReverseMap();
            CreateMap<Categoria, CategoriaResultDto>().ReverseMap();
            CreateMap<Livro, LivroAddDto>().ReverseMap();
            CreateMap<Livro, LivroEditDto>().ReverseMap();
            CreateMap<Livro, LivroResultDto>().ReverseMap();
        }
    }
}
