using System;
using EFApplication.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFApplication.DAL
{
    public class DBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

    }
    /// <summary>
    /// Migrations
    /// </summary>
    public class DBContextFactory : IDesignTimeDbContextFactory<DBContext>
    {
        public DBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductsDB;Integrated Security=True",b=>b.MigrationsAssembly("EFApplication.DAL"));
            return new DBContext(optionsBuilder.Options);
        }
    }
}
