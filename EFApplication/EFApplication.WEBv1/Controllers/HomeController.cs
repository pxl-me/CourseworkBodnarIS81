using AutoMapper;
using EFApplication.BLL.Interfaces;
using EFApplication.DAL.Entities;
using EFApplication.WEBv1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EFApplication.WEBv1.Controllers
{
    public class HomeController : Controller
    {
        private ISupplierService _supplierService;

        public HomeController(ISupplierService supplierService)
        {

            _supplierService = supplierService;
        }

        public IActionResult Index()
        {

            List<Supplier> supplier = _supplierService.GetSuppliers().ToList();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierViewModel>()).CreateMapper();
            List<SupplierViewModel> supplierViewModel =
                mapper.Map<IEnumerable<Supplier>, List<SupplierViewModel>>(supplier);
            return View(supplierViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
