
using EFApplication.DAL;
using EFApplication.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EFApplication.DAL.Interfaces;

namespace EFApplication.DAL.Repositories
{
    public class SupplierRepository : ISupplierRepository

    {
        private readonly DBContext db;

        public SupplierRepository(DBContext context)
        {
            this.db = context;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return db.Suppliers;
        }

        public Supplier Get(int id)
        {

            return db.Suppliers.Find(id);
        }

        public void Create(Supplier supplier)
        {
            if (supplier != null)
                db.Suppliers.Add(supplier);

        }

        public void Update(Supplier supplier)
        {
            if (supplier != null)
                db.Entry(supplier).State = EntityState.Modified;

        }

        //public IEnumerable<Supplier> GetSuppliersByCategory(string category)
        //{
        //    return db.Suppliers.Where(s => s.Products.Any(p => p.ProductCategory.Name == category));

        //}

        //public IEnumerable<Supplier> Find(Func<Supplier, Boolean> predicate)
        //{
        //    return db.Suppliers.Where(predicate).ToList();
        //}

        public void Delete(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier != null)
                db.Suppliers.Remove(supplier);

        }
        
    }
}