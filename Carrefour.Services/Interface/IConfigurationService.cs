using Carrefour.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carrefour.Services.Interface
{
    public interface IConfigurationService
    {
        Task<Configuration> GetConfigurations();
        Task<Configuration> GetConfigurationByID(int ID);
        Task UpdateConfiguration(Configuration configuration);
        Task DeleteConfiguration(int ID);

        Task NewConfiguration(Configuration configuration);
    }
}