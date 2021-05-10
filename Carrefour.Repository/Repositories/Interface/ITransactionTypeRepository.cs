using Carrefour.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Repository.Repositories.Interface
{
    public interface ITransactionTypeRepository
    {
        Task<ICollection<TransactionType>> GetTransactionTypes();
        Task<TransactionType> GetTransactionTypeByID(int ID);
        Task NewTransactionType(TransactionType transactionType);
        Task UpdateTransactionType(TransactionType transactionType);
        Task DeleteTransactionType(int ID);
        Task Save();
    }
}
