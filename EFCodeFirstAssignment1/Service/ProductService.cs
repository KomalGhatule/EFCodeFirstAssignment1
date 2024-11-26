using EFCodeFirstAssignment1.Context;
using EFCodeFirstAssignment1.Interface;
using EFCodeFirstAssignment1.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstAssignment1.Service
{
    public class ProductService : IProduct
    {
        private readonly CustomerDbContext _dbContext;

        public ProductService(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByID(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(emp => emp.ProductID == id);
        }
        public async Task<Product?> AddProduct(Product obj)
        {
            var addProduct= new Product()
            {
               
                ProductName = obj.ProductName,
                Description = obj.Description,
                StockQuantity = obj.StockQuantity,
                CreatedDate= DateTime.Now,
            };
            _dbContext.Products.Add(addProduct);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? addProduct : null;
        }
        public async Task<bool> DeleteProductByID(int id)
        {
            var hero = await _dbContext.Products.FirstOrDefaultAsync(index => index.ProductID == id);
            if (hero != null)
            {
                _dbContext.Products.Remove(hero);
                var result = await _dbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }

    }
}
