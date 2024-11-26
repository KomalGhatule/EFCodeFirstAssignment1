using EFCodeFirstAssignment1.Context;
using EFCodeFirstAssignment1.Interface;
using EFCodeFirstAssignment1.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstAssignment1.Service
{
    public class OrderHistoryService:IOrderHistory
    {
        private readonly CustomerDbContext _dbContext;
        public OrderHistoryService(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<OrderHistory>> GetAllOrderHistory()
        {
            return await _dbContext.OrderHistories.ToListAsync();
        }
        public async Task<OrderHistory?> GetOrderHistoryByID(int id)
        {
            return await _dbContext.OrderHistories.FirstOrDefaultAsync(order=>order.OrderHistoryID==id);
        }
        public async Task<OrderHistory?> AddOrderHistory(OrderHistory obj)
        {
            var addOrderHistory = new OrderHistory()
            {
                ProductID = obj.ProductID,
                Quantity = obj.Quantity,
                UnitPrice = obj.UnitPrice,
            };
            _dbContext.OrderHistories.Add(addOrderHistory);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? addOrderHistory : null;
        }

        public async Task<bool> DeleteOrderHistoryByID(int id)
        {
            var hero = await _dbContext.OrderHistories.FirstOrDefaultAsync(index => index.OrderHistoryID == id);
            if(hero!=null)
            {
                _dbContext.OrderHistories.Remove(hero);
                var result=await _dbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}
