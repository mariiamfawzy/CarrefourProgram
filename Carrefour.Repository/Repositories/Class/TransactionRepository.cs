using Carrefour.Domain.Models;
using Carrefour.Repository.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Repository.Repositories.Class
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationContext _dbContext;
        public TransactionRepository(ApplicationContext context)
        {
            _dbContext = context;
        }

        public async Task DeleteTransaction(int ID)
        {
            var transaction = await _dbContext.Transactions.FindAsync(ID);
            if (transaction != null) _dbContext.Transactions.Remove(transaction);
        }

        public async Task<Transaction> GetTransactionByID(int ID)
        {
            return await _dbContext.Transactions.FindAsync(ID);
        }

        public async Task<ICollection<Transaction>> GetTransactions()
        {
            return await _dbContext.Transactions.AsNoTracking().ToListAsync();
        }

        public async Task NewTransaction(Transaction transaction)
        {
            await _dbContext.Transactions.AddAsync(transaction);
            await Save();
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTransaction(Transaction transaction)
        {
            _dbContext.Transactions.Update(transaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Transaction>> GetRedeemableTransactions()
        {
            return await _dbContext.Transactions.AsNoTracking().Where(t => t.CreatedDate <= System.DateTime.Now.AddDays(90)).ToListAsync();
        }

        public async Task<ICollection<Transaction>> GetCustomerBalance(int ID)
        {
            return await _dbContext.Transactions.AsNoTracking().Where(x => x.CustomerID == ID && x.CreatedDate <= System.DateTime.Now.AddDays(90)).ToListAsync();
        }

        public async Task<int> GetCustomerTotalBalance(int ID)
        {

            var sum = await _dbContext.Transactions.AsNoTracking().Where(x => x.CustomerID == ID && x.CreatedDate <= System.DateTime.Now.AddDays(90)).SumAsync(x => x.XPoints);
            return sum;
        }

        public async Task<ICollection<Transaction>> GetRedeemedBalance(int ID)
        {
            return await _dbContext.Transactions.AsNoTracking().Where(x => x.CustomerID == ID && x.CreatedDate <= System.DateTime.Now.AddDays(90)).ToListAsync();
        }
    }
}

