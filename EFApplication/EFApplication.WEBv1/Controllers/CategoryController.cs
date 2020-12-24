using AutoMapper;
using EFApplication.DAL.Entities;
using EFApplication.DAL.Interfaces;
using EFApplication.WEBv1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EFApplication.BLL.Interfaces;

namespace EFApplication.WEBv1.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {

            _categoryService = categoryService;
        }
        public IActionResult Index(string? CategoryName)
        {

            List<Category> category = _categoryService.GetCategories().ToList();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryViewModel>()).CreateMapper();
            List<CategoryViewModel> categoryViewModel = mapper.Map<IEnumerable<Category>, List<CategoryViewModel>>(category);

            if (CategoryName != "" && CategoryName != null)
            {
                return View(mapper.Map<IEnumerable<Category>, List<CategoryViewModel>>(_categoryService.GetCategories().Where(t => t.Name == CategoryName)));
            }
            else
            {
                return View(categoryViewModel);
            }
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(CategoryViewModel categoryViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryViewModel, Category>()).CreateMapper();
            var category = mapper.Map<Category>(categoryViewModel);
            _categoryService.Create(category);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateCategory(CategoryViewModel categoryViewModel)
        {

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryViewModel, Category>()).CreateMapper();
            var Category = mapper.Map<Category>(categoryViewModel);
            _categoryService.Update(Category);
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory()
        {
            return View();
        }

    }
}
