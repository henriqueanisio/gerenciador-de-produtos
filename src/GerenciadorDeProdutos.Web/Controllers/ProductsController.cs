using AutoMapper;
using GerenciadorDeProdutos.Domain.Interfaces;
using GerenciadorDeProdutos.Domain.Models;
using GerenciadorDeProdutos.Service.Services;
using GerenciadorDeProdutos.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeProdutos.Web.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService,
            ICategoryService categoryService,
            IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }


        // GET: ProductController
        public async Task<IActionResult> Index(FilterViewModel filterViewModel)
        {
            ViewBag.UsedCategories = _categoryService.GetAll().Result.Distinct();

            return View(_mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetProductsAsync(filterViewModel.SearchString, filterViewModel.IdsCategories, filterViewModel.Situation == "false" ? false : true)));
            
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var ProductViewModel = PopulateCategories(new ProductViewModel()).Result;
            return View(ProductViewModel);
        }

        // POST: ProductController/Create
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            try
            {
                //categoriesViewModel = categoriesViewModel.Where(x => productViewModel.IdsCategories.Contains(x.Id)).ToList();
                var categoriesViewModel = new List<CategoryViewModel>();

                foreach (var id in productViewModel.IdsCategories)
                {
                    var categoryViewModel = new CategoryViewModel();
                    categoryViewModel.Id = id;

                    categoriesViewModel.Add(categoryViewModel);

                }

                productViewModel.Categories = categoriesViewModel;

                var product = await _productService.CreateProductAsync(_mapper.Map<Product>(productViewModel));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var productViewModel = _mapper.Map<ProductViewModel>(await _productService.GetById(id));
            return View(productViewModel);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel productViewModel)
        {
            try
            {
                await _productService.Update(_mapper.Map<Product>(productViewModel));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // POST: ProductController/DeleteById/5
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _productService.DeleteById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<ProductViewModel> PopulateCategories(ProductViewModel productViewModel)
        {
            return _mapper.Map<ProductViewModel>(await _productService.PopulateCategories());
        }
    }
}
