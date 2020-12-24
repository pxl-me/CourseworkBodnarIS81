using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFApplication.BLL.Interfaces;
using EFApplication.DAL.Entities;
using EFApplication.WEBv1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFApplication.WEBv1.Controllers
{
    public class SupplierController : Controller
    {
        private ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        public IActionResult Index(string? SupplierName)
        {
            var supplier = _supplierService.GetSuppliers().ToList();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierViewModel>()).CreateMapper();
            List<SupplierViewModel> supplierViewModel = mapper.Map<IEnumerable<Supplier>, List<SupplierViewModel>>(supplier);
            
            if (SupplierName != "" && SupplierName != null)
            {
                return View(mapper.Map<IEnumerable<Supplier>, List<SupplierViewModel>>(_supplierService.GetSuppliers().Where(t => t.Name == SupplierName)));
            }
            else
            {
                return View(supplierViewModel);
            }

        }
        public IActionResult CreateSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSupplier(SupplierViewModel supplierViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SupplierViewModel, Supplier>()).CreateMapper();
            var supplier = mapper.Map<Supplier>(supplierViewModel);
            _supplierService.Create(supplier);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateSupplier(SupplierViewModel supplierViewModel)
        {

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SupplierViewModel, Supplier>()).CreateMapper();
            var Supplier = mapper.Map<Supplier>(supplierViewModel);
            _supplierService.Update(Supplier);
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSupplier(int id)
        {
            _supplierService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSupplier()
        {
            return View();
        }
    }
}