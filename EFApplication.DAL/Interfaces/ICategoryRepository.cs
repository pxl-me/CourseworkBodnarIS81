using EFApplication.DAL.Entities;
using System.Collections.Generic;

namespace EFApplication.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
        void Create(Category item);
        void Update(Category item);
        void Delete(int id);
       
    }
}