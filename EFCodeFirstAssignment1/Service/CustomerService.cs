using EFCodeFirstAssignment1.Context;
using EFCodeFirstAssignment1.Interface;
using EFCodeFirstAssignment1.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstAssignment1.Service
{
    public class CustomerService : ICustomer

    {
        private readonly CustomerDbContext _dbContext;
        public CustomerService(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Customer>> GetAllCustomer()
        {
            return await _dbContext.Customers.ToListAsync();
        }
        public async Task<Customer?> GetCustomerByID(int id)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(cus => cus.CustomerID == id);
        }
        public async Task<Customer?> AddCustomer(Customer obj)
        {
            var addCustomer = new Customer()
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Email = obj.Email,
                Phone = obj.Phone,
                CreatedDate = obj.CreatedDate,
             };
            _dbContext.Customers.Add(addCustomer);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? addCustomer : null;
        }

        public async Task<Customer?> UpdateCustomer(int id, Customer obj)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(index => index.CustomerID == id);
            if (customer != null)
            {
                customer.FirstName = obj.FirstName;
                customer.LastName = obj.LastName;
                customer.Email = obj.Email;
                customer.Phone = obj.Phone;
                customer.CreatedDate = obj.CreatedDate;
                var result = await _dbContext.SaveChangesAsync();
                return result >= 0 ? customer : null;
            }
            return null;
        }
        public async Task<bool> DeleteCustomerByID(int id)
        {
            var hero = await _dbContext.Customers.FirstOrDefaultAsync(index => index.CustomerID == id);
            if (hero != null)
            {
                _dbContext.Customers.Remove(hero);
                var result = await _dbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }

    }
}
