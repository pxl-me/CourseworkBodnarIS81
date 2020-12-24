
using EFApplication.DAL;
using EFApplication.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EFApplication.DAL.Interfaces;

namespace EFApplication.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DBContext db;

        public ProductRepository(DBContext context)
        {
            this.db = context;
            
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.Include(c => c.Category).Include(c => c.Supplier);
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public void Create(Product product)
        {
            if (product != null)
                db.Products.Add(product);
        }

        public void Update(Product product)
        {
            if (product != null)
                db.Entry(product).State = EntityState.Modified;
        }

        //public IEnumerable<Product> Find(Func<Product, Boolean> predicate)
        //{
        //    return db.Products.Include(c => c.ProductCategory).Include(c => c.Supplier).Where(predicate).ToList();
        //}

        public void Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
                db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product GetByName(string name)
        {
            return db.Products.Find(name);
        }

    }
}