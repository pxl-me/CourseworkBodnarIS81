using AutoMapper;
using EFApplication.BLL.Interfaces;
using EFApplication.DAL.Entities;
using EFApplication.WEBv1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EFApplication.WEBv1.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult Index(string? ProductName)
        {
            var product = _productService.GetProducts().ToList();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductViewModel>()).CreateMapper();
            List<ProductViewModel> productViewModel = mapper.Map<IEnumerable<Product>, List<ProductViewModel>>(product);

            if (ProductName != "" && ProductName != null)
            {
                return View(mapper.Map<IEnumerable<Product>, List<ProductViewModel>>(_productService.GetProducts().Where(t => t.Name == ProductName)));
            }
            else
            {
                return View(productViewModel);
            }
            

        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(ProductViewModel productViewModel)
        {

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductViewModel, Product>()).CreateMapper();
            var product = mapper.Map<Product>(productViewModel);
            _productService.Create(product);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateProduct(ProductViewModel productViewModel)
        {

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductViewModel, Product>()).CreateMapper();
            var product = mapper.Map<Product>(productViewModel);
            _productService.Update(product);
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id)
        {        
            _productService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct()
        {
            return View();
        }
    }
}