using Carrefour.Domain.Models;
using Carrefour.Repository.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Repository.Repositories.Class
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly ApplicationContext _dbContext;
        public TransactionTypeRepository(ApplicationContext context)
        {
            _dbContext = context;
        }

        public async Task DeleteTransactionType(int ID)
        {
            var transactionType = await _dbContext.TransactionTypes.FindAsync(ID);
            if (transactionType != null) _dbContext.TransactionTypes.Remove(transactionType);
        }

        public async Task<TransactionType> GetTransactionTypeByID(int ID)
        {
            return await _dbContext.TransactionTypes.FindAsync(ID);
        }

        public async Task<ICollection<TransactionType>> GetTransactionTypes()
        {
            return await _dbContext.TransactionTypes.AsNoTracking().ToListAsync();
        }

        public async Task NewTransactionType(TransactionType transactionType)
        {
            await _dbContext.TransactionTypes.AddAsync(transactionType);
            await Save();
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTransactionType(TransactionType transactionType)
        {
            _dbContext.TransactionTypes.Update(transactionType);
            await _dbContext.SaveChangesAsync();
        }
    }
}