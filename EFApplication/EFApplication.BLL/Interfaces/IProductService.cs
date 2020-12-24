using EFApplication.DAL.Entities;
using System.Collections.Generic;

namespace EFApplication.BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsByCategory(string category);
        IEnumerable<Product> GetProductsBySupplier(string supplier);
        Product GetProductMinPrice();
        Product GetProduct(int? id);
        IEnumerable<Product> GetProducts();
        void Create(Product prod);
        void Update(Product product);
        void Delete(int? id);
        void Dispose();

    }
}