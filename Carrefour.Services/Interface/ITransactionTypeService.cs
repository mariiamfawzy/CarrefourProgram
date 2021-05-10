using Carrefour.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Services.Interface
{
    public interface ITransactionTypeService
    {
        Task<ICollection<TransactionType>> GetTransactionTypes();
        Task NewTransactionType(TransactionType transactionType);
        Task<TransactionType> GetTransactionTypeByID(int id);
        Task UpdateTransactionType(TransactionType transactionType);
        Task DeleteTransactionType(int id);
    }
}