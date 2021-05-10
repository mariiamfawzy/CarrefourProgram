using Carrefour.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Repository.Repositories.Interface
{
    public interface ITransactionRepository
    {
        Task<ICollection<Transaction>> GetTransactions();
        Task<Transaction> GetTransactionByID(int ID);
        Task NewTransaction(Transaction transaction);
        Task UpdateTransaction(Transaction transaction);
        Task DeleteTransaction(int ID);
        Task<ICollection<Transaction>> GetRedeemableTransactions();
        Task<ICollection<Transaction>> GetCustomerBalance(int ID);

        Task<ICollection<Transaction>> GetRedeemedBalance(int ID);
        Task<int> GetCustomerTotalBalance(int ID);
        Task Save();
    }
}