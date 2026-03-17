namespace Polifood.Interfaces
{
    public interface IVendorService
    {
        Task<List<Product>> GetAll();
        Task<Product?> getById(Guid id);

        Task<Product> Create(Product product);

        Task<bool> Update(Guid id, Product product);

        Task<bool> ChangeStatus(Guid id);
    }
}
