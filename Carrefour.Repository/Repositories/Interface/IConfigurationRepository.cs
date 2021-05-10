using Carrefour.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Repository.Repositories.Interface
{
    public interface IConfigurationRepository
    {
        Task<Configuration> GetConfigurations();
        Task<Configuration> GetConfigurationByID(int ID);
        Task NewConfiguartion(Configuration configuration);
        Task UpdateConfiguration(Configuration configuration);
        Task DeleteConfiguration(int ID);
        Task Save();
    }
}