using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using WebEditor.Services;

namespace WebEditor.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _configurationService.ListConfigurations();

            return View(items);
        }
    }
}
