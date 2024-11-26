using EFCodeFirstAssignment1.Model;

namespace EFCodeFirstAssignment1.Interface
{
    public interface IProduct
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> GetProductByID(int id);
        Task<Product?> AddProduct(Product obj);
        //Task<Product?> UpdateProduct(int  id, Product obj);
        Task<bool> DeleteProductByID(int id);
    }
}
