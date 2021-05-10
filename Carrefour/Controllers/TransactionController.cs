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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        [Route("GetTransactions")]
        public async Task<ICollection<Transaction>> GetTransactions()
        {
            try
            {
                return await _transactionService.GetTransactions();
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetRedeemableTransactions")]
        public async Task<ICollection<Transaction>> GetRedeemableTransactions()
        {
            try
            {
                return await _transactionService.GetRedeemableTransactions();
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetCustomerBalance")]
        public async Task<ICollection<Transaction>> GetCustomerBalance([FromQuery] int id)
        {
            try
            {
                return await _transactionService.GetCustomerBalance(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        [Route("GetTransactionByID")]
        public async Task<ActionResult<Transaction>> GetTransactionByID([FromQuery] int id)
        {
            try
            {
                return await _transactionService.GetTransactionByID(id);

            }
            catch (Exception)
            {
                return NotFound();

            }
        }

        [HttpPost]
        [Route("NewTransaction")]
        public async Task<ActionResult<Transaction>> NewTransaction(Transaction transaction)
        {
            try
            {
                await _transactionService.NewTransaction(transaction);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("UpdateTransaction")]
        public async Task<IActionResult> UpdateTransaction(Transaction transaction)
        {
            try
            {
                await _transactionService.UpdateTransaction(transaction);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            try
            {
                await _transactionService.DeleteTransaction(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
