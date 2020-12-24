using EFApplication.DAL.Entities;
using System.Collections.Generic;

namespace EFApplication.DAL.Interfaces
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAll();
        Supplier Get(int id);
        //  IEnumerable<Supplier> Find(Func<Supplier, Boolean> predicate);
        void Create(Supplier item);
        void Update(Supplier item);
        //  IEnumerable<Supplier> GetSuppliersByCategory(string category);
        void Delete(int id);
      
    }
}