using Carrefour.Domain.Models;
using Carrefour.Repository.Repositories.Interface;
using Carrefour.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Services.Class
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task DeleteCustomer(int id)
        {
            try
            {
                await _customerRepository.DeleteCustomer(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Customer> GetCustomerByID(int id)
        {
            try
            {
                return await _customerRepository.GetCustomerByID(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<Customer>> GetCustomers()
        {
            try
            {
                return await _customerRepository.GetCustomers();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task NewCustomer(Customer customer)
        {

            try
            {
                if (customer != null)
                {
                    await _customerRepository.NewCustomer(customer);
                }
                else
                {
                    throw new Exception("Null Customer Object");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateCustomer(Customer customer)
        {

            if (customer != null)
            {
                var tempUser = await _customerRepository.GetCustomerByID(customer.ID);
                if (tempUser != null)
                {
                    await _customerRepository.UpdateCustomer(customer);
                }
                else
                {
                    throw new Exception("Not Found");
                }
            }
        }
    }
}

