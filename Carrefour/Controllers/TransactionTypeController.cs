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
    public class TransactionTypeController : ControllerBase
    {
        private readonly ITransactionTypeService _transactionTypeService;
        public TransactionTypeController(ITransactionTypeService transactionTypeService)
        {
            _transactionTypeService = transactionTypeService;
        }

        [HttpGet]
        public async Task<ICollection<TransactionType>> GetTransactionTypes()
        {
            try
            {
                return await _transactionTypeService.GetTransactionTypes();
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        [Route("GetTransactionTypeByID")]
        public async Task<ActionResult<TransactionType>> GetTransactionTypeByID([FromQuery] int id)
        {
            try
            {
                return await _transactionTypeService.GetTransactionTypeByID(id);

            }
            catch (Exception)
            {
                return NotFound();

            }
        }

        [HttpPost]
        public async Task<ActionResult<TransactionType>> NewTransactionType(TransactionType transactionType)
        {
            try
            {
                await _transactionTypeService.NewTransactionType(transactionType);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateTransactionType(TransactionType transactionType)
        {
            try
            {
                await _transactionTypeService.UpdateTransactionType(transactionType);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionType(int id)
        {
            try
            {
                await _transactionTypeService.DeleteTransactionType(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}