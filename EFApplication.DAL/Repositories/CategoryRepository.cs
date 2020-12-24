
using EFApplication.DAL;
using EFApplication.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EFApplication.DAL.Interfaces;

namespace EFApplication.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly DBContext db;

        public CategoryRepository(DBContext context)
        {
            this.db = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public void Create(Category productCategory)
        {
            if (productCategory != null)
                db.Categories.Add(productCategory);

        }

        public void Update(Category productCategory)
        {
            if (productCategory != null)
                db.Entry(productCategory).State = EntityState.Modified;

        }

        //public IEnumerable<ProductCategory> Find(Func<ProductCategory, Boolean> predicate)
        //{
        //    return db.ProductCategories.Where(predicate).ToList();
        //}

        public void Delete(int id)
        {
            Category productCategory = db.Categories.Find(id);
            if (productCategory != null)
                db.Categories.Remove(productCategory);

        }

       
    }
}