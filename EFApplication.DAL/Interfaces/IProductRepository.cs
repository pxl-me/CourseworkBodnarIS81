using EFApplication.DAL.Entities;
using System.Collections.Generic;



namespace EFApplication.DAL.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        //  IEnumerable<Product> Find(Func<Product, Boolean> predicate);
        void Create(Product item);
        void Update(Product item);
        void Delete(int id);
      //  void Find (int id);

       
    }
}