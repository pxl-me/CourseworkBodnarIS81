using System;
using System.Collections.Generic;
using EFApplication.DAL.Entities;

namespace EFApplication.BLL.Interfaces
{
    public interface ICategoryService:IDisposable
    {
 
        IEnumerable<Category> GetCategories();
        Category GetCategory(int? id);
        void Create(Category category);
        void Update(Category category);
        void Delete(int? id);
        void Dispose();
    }
}