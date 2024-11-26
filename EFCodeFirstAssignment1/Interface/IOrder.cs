using EFCodeFirstAssignment1.Model;

namespace EFCodeFirstAssignment1.Interface
{
    public interface IOrder
    {
        Task<List<Order>> GetAllOrders();
        Task<Order?> GetOrderById(int id);
        Task<Order?> AddOrder(Order obj);
        // Task<Order?> UpdateOrder(Order obj, int id);
        Task<bool> DeleteOrderById(int id);

    }
}
