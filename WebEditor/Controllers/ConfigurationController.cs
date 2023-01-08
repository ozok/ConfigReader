using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using WebEditor.Services;
using WebEditor.ViewModels;

namespace WebEditor.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _configurationService.ListConfigurations();

            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int configId)
        {
            var model = await _configurationService.GetConfigurationEditViewModel(configId);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] ConfigurationEditViewModel model)
        {
            var config = await _configurationService.EditConfiguration(model);
            if (config == null)
            {
                return NotFound();
            }

            return RedirectToAction("Edit", new { configId = config.Id });
        }
    }
}
