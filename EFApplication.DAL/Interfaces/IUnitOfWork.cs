namespace EFApplication.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        ISupplierRepository Suppliers { get; }
        void Save();
       // void Where();
       // void Entry();
       // void Delete();
        void Dispose();
    }
}