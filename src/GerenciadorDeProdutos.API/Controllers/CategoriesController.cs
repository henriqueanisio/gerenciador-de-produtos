using AutoMapper;
using GerenciadorDeProdutos.API.ViewModels;
using GerenciadorDeProdutos.Domain.Interfaces;
using GerenciadorDeProdutos.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeProdutos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {

        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ILogger<CategoriesController> logger,
            ICategoryService categoryService, IMapper mapper)
        {
            _logger = logger;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos as categorias.
        /// </summary>

        [HttpGet]
        [ProducesResponseType(typeof(CategoryViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(string? searchDescription = "", bool situation = true)
        {
            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.GetCategoriesAsync(searchDescription, situation));

            if (categories.Any())
                return Ok(categories);

            return NotFound();
        }

        /// <summary>
        /// Cadastra uma nova categoria
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(CategoryViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CategoryViewModel categoryViewModel)
        {
            var categoryCreated = await _categoryService.Create(_mapper.Map<Category>(categoryViewModel));

            if (categoryCreated != null)
                return Created("", categoryCreated);

            return BadRequest();
        }

        /// <summary>
        /// Altera uma categoria
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(CategoryViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(UpdateCategoryViewModel categoryViewModel)
        {

            var categoryAltered = await _categoryService.Update(_mapper.Map<Category>(categoryViewModel));
            
            if (categoryAltered != null)
                return Ok(categoryAltered);

            return BadRequest();
        }

        /// <summary>
        /// Deleta uma categoria
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _categoryService.DeleteById(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}