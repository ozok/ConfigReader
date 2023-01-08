using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingsController : ControllerBase
    {
        private readonly ConfigurationReader.ConfigurationReader _configurationReader;

        public SettingsController(ConfigurationReader.ConfigurationReader configurationReader = null)
        {
            _configurationReader = configurationReader;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var siteName = await _configurationReader.GetValueAsync<string>("SiteName");
            var maxItemCount = await _configurationReader.GetValueAsync<int>("MaxItemCount");
            return new string[] { siteName, maxItemCount.ToString() };
        }
    }
}
