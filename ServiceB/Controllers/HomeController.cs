using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConfigurationReader.ConfigurationReader _configurationReader;

        public HomeController(ILogger<HomeController> logger, ConfigurationReader.ConfigurationReader configurationReader)
        {
            _logger = logger;
            _configurationReader = configurationReader;
        }

        public IActionResult Index()
        {
            List<string> list = new List<string>();

            string isBasketEnabled = _configurationReader.GetValue<string>("IsBasketEnabled");
            list.Add($"IsBasketEnabled : {isBasketEnabled}");
            string test2 = _configurationReader.GetValue<string>("test2");
            list.Add($"test2 : {test2}");
            var siteName = _configurationReader.GetValue<string>("SiteName"); // SERVICE-A'ya ait, okuyamaz
            list.Add($"SiteName : {siteName}");

            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
