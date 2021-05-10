using Carrefour.Domain.Models;
using Carrefour.Repository.Repositories.Interface;
using Carrefour.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Services.Class
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;
        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }
        public async Task DeleteConfiguration(int ID)
        {
            await _configurationRepository.DeleteConfiguration(ID);
        }

        public async Task<Configuration> GetConfigurationByID(int ID)
        {
            return await _configurationRepository.GetConfigurationByID(ID);
        }

        public async Task<Configuration> GetConfigurations()
        {
            try
            {
                return await _configurationRepository.GetConfigurations();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task NewConfiguration(Configuration configuration)
        {
            if (configuration != null)
                await _configurationRepository.NewConfiguartion(configuration);
        }

        public async Task UpdateConfiguration(Configuration configuration)
        {
            try
            {
                if (configuration == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    await _configurationRepository.UpdateConfiguration(configuration);
                }
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}

