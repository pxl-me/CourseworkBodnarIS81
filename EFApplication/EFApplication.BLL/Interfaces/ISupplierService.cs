using EFApplication.DAL.Entities;
using System.Collections.Generic;

namespace EFApplication.BLL.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetSuppliersByCategory(string category);
        IEnumerable<Supplier> GetSuppliers();
        Supplier GetSupplier(int? id);
        void Create(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(int? id);
        void Dispose();
    }
}