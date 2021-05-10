using Carrefour.Domain.Models;
using Carrefour.Repository.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Repository.Repositories.Class
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ApplicationContext _dbContext;
        public ConfigurationRepository(ApplicationContext context)
        {
            _dbContext = context;
        }

        public async Task DeleteConfiguration(int ID)
        {
            var configuration = await _dbContext.Configurations.FindAsync(ID);
            if (configuration != null) _dbContext.Configurations.Remove(configuration);
        }

        public async Task<Configuration> GetConfigurationByID(int ID)
        {
            return await _dbContext.Configurations.FindAsync(ID);
        }

        public async Task<Configuration> GetConfigurations()
        {
            try
            {
                var configurations = await _dbContext.Configurations.AsNoTracking().FirstOrDefaultAsync();
                return configurations;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task NewConfiguartion(Configuration configuration)
        {
            if (configuration != null)
            {
                await _dbContext.Configurations.AddAsync(configuration);
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task UpdateConfiguration(Configuration configuration)
        {
            throw new NotImplementedException();
        }

    }
}
