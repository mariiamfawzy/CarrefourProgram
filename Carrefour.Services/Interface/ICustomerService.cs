using Carrefour.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Services.Interface
{
    public interface ICustomerService
    {
        Task<ICollection<Customer>> GetCustomers();
        Task NewCustomer(Customer customer);
        Task<Customer> GetCustomerByID(int id);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int id);
    }
}