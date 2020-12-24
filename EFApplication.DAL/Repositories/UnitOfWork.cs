using System;
using EFApplication.DAL.Entities;
using EFApplication.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EFApplication.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DBContext db;
        private ICategoryRepository categoryRepository;
        private IProductRepository productRepository;
        private ISupplierRepository supplierRepository;
        
        public UnitOfWork(DBContext context, ICategoryRepository categoryRepository, IProductRepository productRepository, ISupplierRepository supplierRepository)
        {
            this.db = context;
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
            this.supplierRepository = supplierRepository;
        }

        public DBContext Context { get { return db; } }
        public IProductRepository Products
        {
            get
            {
                return productRepository;
            }
        }

        public ICategoryRepository Categories
        {
            get
            {

                return categoryRepository;
            }
        }

        public ISupplierRepository Suppliers
        {
            get
            {
                return supplierRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //public void Delete()
        //{
        //    db.Remove(this); 
        //}
    }
    
}