using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        //Injecting the necessary services.
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //This will return type categoryDTO
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }

        //Create
        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        //Edit
        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryDto = await _categoryService.GetById(id);
            if (categoryDto == null)
            {
                return NotFound();
            }

            return View(categoryDto);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.Update(categoryDto);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDto);
        }

        //Delete
        [Authorize(Roles = "Admin")]
        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryDto = await _categoryService.GetById(id);
            if (categoryDto == null)
            {
                return NotFound();
            }

            return View(categoryDto);
        }

        //Another action name is created to prevent method conflict.
        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.Remove(id);
            return RedirectToAction("Index");
        }

        //Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryDto = await _categoryService.GetById(id);
            if (categoryDto == null)
            {
                return NotFound();
            }

            return View(categoryDto);
        }
    }
}
