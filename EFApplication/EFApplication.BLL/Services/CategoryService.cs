using System.Collections.Generic;
using System.Linq;
using EFApplication.BLL.Interfaces;
using EFApplication.DAL.Entities;
using EFApplication.DAL.Interfaces;

namespace EFApplication.BLL.Services
{
    public class CategoryService:ICategoryService
    {
        private IUnitOfWork Database { get; set; }

        public CategoryService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
      

        public IEnumerable<Category> GetCategories()
        {

            return Database.Categories.GetAll();
        }

        public Category GetCategory(int? id)
        {

            var category = Database.Categories.Get(id.Value);
            return new Category
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public void Create(Category category)
        {
            Database.Categories.Create(category);
            Database.Save();
        }
        public void Update(Category category)
        {
            Database.Categories.Update(category);
            Database.Save();
        }
        public void Delete(int? id)
        {
            Database.Categories.Delete(id.Value);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}