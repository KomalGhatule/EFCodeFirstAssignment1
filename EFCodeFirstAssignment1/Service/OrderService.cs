using EFCodeFirstAssignment1.Context;
using EFCodeFirstAssignment1.Interface;
using EFCodeFirstAssignment1.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstAssignment1.Service
{
    public class OrderService:IOrder
    {
        private readonly CustomerDbContext _dbContext;
        public OrderService(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _dbContext.Orders.ToListAsync();
        }
        public async Task<Order?> GetOrderById(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(odr=>odr.OrderID==id);
        }
        public async Task<Order?> AddOrder(Order obj)
        {
            var addOrder = new Order()
            {
                CustomerID = obj.CustomerID,
                OrderDate = obj.OrderDate,
                TotalAmount = obj.TotalAmount,
            };
            _dbContext.Orders.Add(addOrder);
            var result= await _dbContext.SaveChangesAsync();
            return result >= 0 ? addOrder : null;
        }

        public async Task<bool> DeleteOrderById(int id)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(index => index.OrderID == id);
            if(order!=null)
            {
                _dbContext.Orders.Remove(order);
                var result=await _dbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }

    }
}
