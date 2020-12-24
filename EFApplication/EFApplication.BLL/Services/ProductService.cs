using EFApplication.BLL.Interfaces;
using EFApplication.DAL.Entities;
using EFApplication.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EFApplication.BLL.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork Database { get; set; }

        public ProductService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {

            return Database.Products.GetAll().Where(p => p.Category.Name == category);
        }
        public IEnumerable<Product> GetProductsBySupplier(string supplier)
        {

            return Database.Products.GetAll().Where(p => p.Supplier.Name == supplier);
        }

        public Product GetProductMinPrice()
        {
            var product = Database.Products.GetAll().OrderBy(p => p.Price).FirstOrDefault();
            return new Product
            {
                Name = product.Name,
                Id = product.Id,
                Price = product.Price,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId
            };
        }

        public Product GetProduct(int? id)
        {
            var product = Database.Products.Get(id.Value);
            return new Product
            {
                Name = product.Name,
                Id = product.Id,
                Price = product.Price,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId
            };
        }

        public IEnumerable<Product> GetProducts()
        {

            return Database.Products.GetAll();
        }

        public void Create(Product prod)
        {
            Supplier supplier = Database.Suppliers.Get(prod.SupplierId);
            Category productCategory = Database.Categories.Get(prod.CategoryId);
            Product product = new Product
            {
                Id = prod.Id,
                Name = prod.Name,
                Price = prod.Price,
                Category = productCategory,
                CategoryId = productCategory.Id,
                Supplier = supplier,
                SupplierId = supplier.Id
            };
            Database.Products.Create(product);
            Database.Save();
        }
        public void Update(Product product)
        {

            Database.Products.Update(product);
            Database.Save();
        }
        public void Delete(int? id)
        {
            //Product b = Database.Products.Find(id.Value);
            //Database.Products.Get(id.Value);
            // return Database.Products.Delete(p).Where(p => p.Id == id);
            Database.Products.Delete(id.Value);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}