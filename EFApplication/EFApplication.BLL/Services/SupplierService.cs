using EFApplication.BLL.Interfaces;
using EFApplication.DAL.Entities;
using EFApplication.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EFApplication.BLL.Services
{
    public class SupplierService : ISupplierService
    {
        private IUnitOfWork Database { get; set; }

        public SupplierService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
        public IEnumerable<Supplier> GetSuppliersByCategory(string category)
        {

            return Database.Suppliers.GetAll().Where(s => s.Products.Any(p => p.Category.Name == category));
        }

        public IEnumerable<Supplier> GetSuppliers()
        {

            return Database.Suppliers.GetAll();
        }

        public Supplier GetSupplier(int? id)
        {

            var supplier = Database.Suppliers.Get(id.Value);
            return new Supplier
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Region = supplier.Region
            };
        }

        public void Create(Supplier supplier)
        {
            Database.Suppliers.Create(supplier);
            Database.Save();
        }
        public void Update(Supplier supplier)
        {
            Database.Suppliers.Update(supplier);
            Database.Save();
        }
        public void Delete(int? id)
        {
            Database.Suppliers.Delete(id.Value);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}