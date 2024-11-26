using EFCodeFirstAssignment1.Model;

namespace EFCodeFirstAssignment1.Interface
{
    public interface ICustomer
    {
        Task<List<Customer>> GetAllCustomer();
        Task<Customer?> GetCustomerByID(int id);
        Task<Customer?> AddCustomer(Customer obj);

        //Task<Customer?> UpdateCustomer(int id, Customer obj);
        Task<bool> DeleteCustomerByID(int id);
    }
}
