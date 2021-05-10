using Carrefour.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Services.Interface
{
    public interface ITransactionService
    {
        Task<ICollection<Transaction>> GetTransactions();
        Task NewTransaction(Transaction transaction);
        Task<Transaction> GetTransactionByID(int id);
        Task UpdateTransaction(Transaction transaction);
        Task<ICollection<Transaction>> GetRedeemableTransactions();
        Task<ICollection<Transaction>> GetCustomerBalance(int ID);
        Task<ICollection<Transaction>> GetRedeemedBalance(int ID);
        Task<int> GetCustomerTotalBalance(int ID);
        Task DeleteTransaction(int id);
    }
}
