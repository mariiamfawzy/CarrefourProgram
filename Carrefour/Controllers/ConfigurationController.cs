using Carrefour.Domain.Models;
using Carrefour.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrefour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {

        private readonly IConfigurationService _configurationService;
        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }
        [HttpGet]
        [Route("GetConfigurations")]
        public async Task<Configuration> GetConfigurations()
        {
            try
            {
                return await _configurationService.GetConfigurations();
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPatch]
        [Route("UpdateConfigurations")]
        public async Task<IActionResult> UpdateConfigurations(Configuration configuration)
        {
            try
            {
                await _configurationService.UpdateConfiguration(configuration);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }




    }
}
