using Carrefour.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Repository.Repositories.Interface
{
    public interface ICustomerRepository
    {
        Task<ICollection<Customer>> GetCustomers();
        Task<Customer> GetCustomerByID(int ID);

        Task NewCustomer(Customer customer);
        Task DeleteCustomer(int ID);
        Task UpdateCustomer(Customer customer);

        Task Save();
    }
}
