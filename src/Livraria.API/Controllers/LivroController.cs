using AutoMapper;
using Livraria.API.Dtos.Book;
using Livraria.API.Dtos.Category;
using Livraria.Domain.Interfaces.Service;
using Livraria.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.API.Controllers
{
    [Route("api/[controller]")]
    public class LivroController : MainController
    {
        private readonly ILivroService _bookService;
        private readonly IMapper _mapper;

        public LivroController(IMapper mapper,
                                ILivroService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAll();

            return Ok(_mapper.Map<IEnumerable<LivroResultDto>>(books));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetById(id);

            if (book == null) return NotFound();

            return Ok(_mapper.Map<LivroResultDto>(book));
        }

        [HttpGet]
        [Route("get-livro-por-categoria/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBooksByCategory(int categoryId)
        {
            var books = await _bookService.GetBooksByCategory(categoryId);

            if (!books.Any()) return NotFound();

            return Ok(_mapper.Map<IEnumerable<LivroResultDto>>(books));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(LivroAddDto bookDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var book = _mapper.Map<Livro>(bookDto);
            var bookResult = await _bookService.Add(book);

            if (bookResult == null) return BadRequest();

            return Ok(_mapper.Map<LivroResultDto>(bookResult));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, LivroEditDto bookDto)
        {
            if (id != bookDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _bookService.Update(_mapper.Map<Livro>(bookDto));

            return Ok(bookDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            var book = await _bookService.GetById(id);
            if (book == null) return NotFound();

            await _bookService.Remove(book);

            return Ok();
        }

        [HttpGet]
        [Route("busca/{bookName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Livro>>> Search(string bookName)
        {
            var books = _mapper.Map<List<Livro>>(await _bookService.Search(bookName));

            if (books == null || books.Count == 0) return NotFound("None book was founded");

            return Ok(books);
        }

        [HttpGet]
        [Route("busca-livro-com-categoria/{searchedValue}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Livro>>> SearchBookWithCategory(string searchedValue)
        {
            var books = _mapper.Map<List<Livro>>(await _bookService.SearchBookWithCategory(searchedValue));

            if (!books.Any()) return NotFound("None book was founded");

            return Ok(_mapper.Map<IEnumerable<LivroResultDto>>(books));
        }
    }
}
