using Carrefour.Domain.Models;
using Carrefour.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrefour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public async Task<ICollection<Customer>> GetCustomers()
        {
            try
            {
                return await _customerService.GetCustomers();
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        [Route("GetCustomerByID")]
        public async Task<ActionResult<Customer>> GetCustomerByID([FromQuery] int id)
        {
            try
            {
                return await _customerService.GetCustomerByID(id);

            }
            catch (Exception)
            {
                return NotFound();

            }
        }

        [HttpPost]
        [Route("NewCustomer")]
        public async Task<ActionResult<Customer>> NewCustomer(Customer customer)
        {
            try
            {
                await _customerService.NewCustomer(customer);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpPatch("{id}")]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromQuery] long id, Customer customer)
        {
            try
            {
                if (id != customer.ID)
                {
                    return BadRequest();
                }

                await _customerService.UpdateCustomer(customer);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromQuery] int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByID(id);
                if (customer == null)
                {
                    return NotFound();
                }

                await _customerService.DeleteCustomer(id);

                return Ok();
            }
            catch
            {
                return NotFound();
            }
            //try
            //{
            //    await _customerService.DeleteCustomer(id);
            //    return Ok();
            //}
            //catch (Exception)
            //{
            //    return NotFound();
            //}
        }
    }
}
