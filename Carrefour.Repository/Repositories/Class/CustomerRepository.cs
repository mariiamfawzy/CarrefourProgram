using Carrefour.Domain.Models;
using Carrefour.Repository.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Repository.Repositories.Class
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _dbContext;
        public CustomerRepository(ApplicationContext context)
        {
            _dbContext = context;
        }

        public async Task DeleteCustomer(int ID)
        {
            var customer = await _dbContext.Customers.FindAsync(ID);
            if (customer != null) _dbContext.Customers.Remove(customer);
            await Save();
        }

        public async Task<Customer> GetCustomerByID(int ID)
        {
            return await _dbContext.Customers.FindAsync(ID);
        }

        public async Task<ICollection<Customer>> GetCustomers()
        {
            return await _dbContext.Customers.AsNoTracking().ToListAsync();
        }

        public async Task NewCustomer(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await Save();
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            await Save();
        }

    }
}