using Carrefour.Domain.Models;
using Carrefour.Repository.Repositories.Interface;
using Carrefour.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Services.Class
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task DeleteTransaction(int id)
        {
            try
            {
                await _transactionRepository.DeleteTransaction(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Transaction> GetTransactionByID(int id)
        {
            try
            {
                return await _transactionRepository.GetTransactionByID(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<Transaction>> GetTransactions()
        {
            try
            {
                return await _transactionRepository.GetTransactions();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task NewTransaction(Transaction transaction)
        {
            try
            {
                if (transaction != null)
                {
                    await _transactionRepository.NewTransaction(transaction);
                }
                else
                {
                    throw new Exception("Null Object");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateTransaction(Transaction transaction)
        {

            if (transaction != null)
            {
                var tempUser = await _transactionRepository.GetTransactionByID(transaction.ID);
                if (tempUser != null)
                {
                    await _transactionRepository.UpdateTransaction(transaction);
                }
                else
                {
                    throw new Exception("Not Found");
                }
            }
        }

        public async Task<ICollection<Transaction>> GetRedeemableTransactions()
        {
            try
            {
                return await _transactionRepository.GetRedeemableTransactions();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<Transaction>> GetCustomerBalance(int ID)
        {
            try
            {
                return await _transactionRepository.GetCustomerBalance(ID);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}