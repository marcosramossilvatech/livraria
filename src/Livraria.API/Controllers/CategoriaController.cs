﻿using AutoMapper;
using Livraria.API.Dtos.Category;
using Livraria.Domain.Interfaces.Service;
using Livraria.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriaController : MainController
    {
        private readonly ICategoriaService _categoryService;
        private readonly IMapper _mapper;

        public CategoriaController(IMapper mapper,
                                    ICategoriaService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();

            return Ok(_mapper.Map<IEnumerable<CategoriaResultDto>>(categories));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null) return NotFound();

            return Ok(_mapper.Map<CategoriaResultDto>(category));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(CategoriaAddDto categoryDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var category = _mapper.Map<Categoria>(categoryDto);
            var categoryResult = await _categoryService.Add(category);

            if (categoryResult == null) return BadRequest();

            return Ok(_mapper.Map<CategoriaResultDto>(categoryResult));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, CategoriaEditDto categoryDto)
        {
            if (id != categoryDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _categoryService.Update(_mapper.Map<Categoria>(categoryDto));

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null) return NotFound();

            var result = await _categoryService.Remove(category);

            if (!result) return BadRequest();

            return Ok();
        }

        [HttpGet]
        [Route("buscar/{categoria}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Categoria>>> Search(string category)
        {
            var categories = _mapper.Map<List<Categoria>>(await _categoryService.Search(category));

            if (categories == null || categories.Count == 0)
                return NotFound("None category was founded");

            return Ok(categories);
        }
    }

}
