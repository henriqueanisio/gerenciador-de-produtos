using AutoMapper;
using GerenciadorDeProdutos.API.ViewModels;
using GerenciadorDeProdutos.Domain.Interfaces;
using GerenciadorDeProdutos.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeProdutos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(ILogger<ProductsController> logger,
            IProductService productService,
            IMapper mapper)
        {
            _logger = logger;
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos os produtos.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] List<Guid> idsCategories = null, string? searchDescription = "", bool situation = true)
        {
            var products = _mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetProductsAsync(searchDescription, idsCategories, situation));

            if (products.Any())
                return Ok(products);

            return NotFound();
        }

        /// <summary>
        /// Cadastra um novo produto
        /// </summary>

        [HttpPost]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(ProductViewModel productViewModel)
        {
            var productCreated = await _productService.CreateProductAsync(_mapper.Map<Product>(productViewModel), productViewModel.IdsCategories);

            if (productCreated != null)
                return Created("", productCreated);

            return BadRequest();
        }

        /// <summary>
        /// Altera um produto
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(UpdateProductViewModel productViewModel)
        {

            var productAltered = await _productService.UpdateProductAsync(_mapper.Map<Product>(productViewModel), productViewModel.IdsCategories);

            if (productAltered != null)
                return Ok(productAltered);

            return BadRequest();
        }

        /// <summary>
        /// Deleta um produto
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _productService.DeleteById(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}