using Carrefour.Domain.Models;
using Carrefour.Repository.Repositories.Interface;
using Carrefour.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Services.Class
{
    public class TransactionTypeService : ITransactionTypeService
    {

        private readonly ITransactionTypeRepository _transactionTypeRepository;
        public TransactionTypeService(ITransactionTypeRepository transactionTypeRepository)
        {
            _transactionTypeRepository = transactionTypeRepository;
        }

        public async Task DeleteTransactionType(int id)
        {
            try
            {
                await _transactionTypeRepository.DeleteTransactionType(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TransactionType> GetTransactionTypeByID(int id)
        {
            try
            {
                return await _transactionTypeRepository.GetTransactionTypeByID(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<TransactionType>> GetTransactionTypes()
        {
            try
            {
                return await _transactionTypeRepository.GetTransactionTypes();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task NewTransactionType(TransactionType transactionType)
        {
            try
            {
                if (transactionType != null)
                {
                    await _transactionTypeRepository.NewTransactionType(transactionType);
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

        public async Task UpdateTransactionType(TransactionType transactionType)
        {
            if (transactionType != null)
            {
                var temptransactionType = await _transactionTypeRepository.GetTransactionTypeByID(transactionType.ID);
                if (temptransactionType != null)
                {
                    await _transactionTypeRepository.UpdateTransactionType(transactionType);
                }
                else
                {
                    throw new Exception("Not Found");
                }
            }
        }
    }
}