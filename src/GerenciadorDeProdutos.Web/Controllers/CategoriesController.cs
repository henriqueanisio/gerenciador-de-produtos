using AutoMapper;
using GerenciadorDeProdutos.Domain.Interfaces;
using GerenciadorDeProdutos.Domain.Models;
using GerenciadorDeProdutos.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeProdutos.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: CategoriesController
        public async Task<IActionResult> Index(FilterViewModel filterViewModel)
        {
            return View(_mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.GetCategoriesAsync(filterViewModel.SearchString, filterViewModel.Situation == "false" ? false : true)));
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
        {
            try
            {
                await _categoryService.Create(_mapper.Map<Category>(categoryViewModel));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var categoryViewModel = _mapper.Map<CategoryViewModel>(await _categoryService.GetById(id));
            
            return View(categoryViewModel);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel categoryViewModel)
        {
            try
            {
                await _categoryService.Update(_mapper.Map<Category>(categoryViewModel));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _categoryService.DeleteById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
