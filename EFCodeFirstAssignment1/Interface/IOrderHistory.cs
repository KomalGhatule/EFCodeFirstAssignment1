using EFCodeFirstAssignment1.Model;

namespace EFCodeFirstAssignment1.Interface
{
    public interface IOrderHistory
    {
        Task<List<OrderHistory>> GetAllOrderHistory();
        Task<OrderHistory?> GetOrderHistoryByID(int id);
        Task<OrderHistory?> AddOrderHistory(OrderHistory obj);
        //Task<OrderHistory?> UpdateOrderHistory(OrderHistory obj,int id);
        Task<bool> DeleteOrderHistoryByID(int id);
    }
}
