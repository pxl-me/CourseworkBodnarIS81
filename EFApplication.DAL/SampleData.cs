using EFApplication.DAL.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace EFApplication.DAL
{
    public class SampleData
    {
        public static void InitData(DBContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category() { Name = "Fridge" });
                context.Categories.Add(new Category() { Name = "Microwave" });
                context.Categories.Add(new Category() { Name = "Phone" });
                context.SaveChanges();
            }

            if (!context.Suppliers.Any())
            {
                context.Suppliers.Add(new Supplier() { Name = "Samsung", Region = "Kyiv" });
                context.Suppliers.Add(new Supplier() { Name = "LG", Region = "Odessa" });
                context.Suppliers.Add(new Supplier() { Name = "Asus", Region = "Lviv" });
                context.Suppliers.Add(new Supplier() { Name = "OnePlus", Region = "Kharkiv" });
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                context.Products.Add(new Product()
                {

                    CategoryId = 1,
                    SupplierId = 2,
                    Name = "LG FL100",
                    Price = 25000,
                    Category = context.Categories.Find(1),
                    Supplier = context.Suppliers.Find(2)
                });
                context.Products.Add(new Product()
                {

                    CategoryId = 3,
                    SupplierId = 4,
                    Name = "OnePlus 7 Pro",
                    Price = 16000,
                    Category = context.Categories.Find(4),
                    Supplier = context.Suppliers.Find(4)
                });
                context.Products.Add(new Product()
                {

                    CategoryId = 3,
                    SupplierId = 3,
                    Name = "Asus Rog Phone",
                    Price = 12000,
                    Category = context.Categories.Find(4),
                    Supplier = context.Suppliers.Find(3)
                });
                context.Products.Add(new Product()
                {

                    CategoryId = 2,
                    SupplierId = 1,
                    Name = "Samsung MV20",
                    Price = 4000,
                    Category = context.Categories.Find(2),
                    Supplier = context.Suppliers.Find(1)
                });
                context.SaveChanges();
            }
        }
    }
}