using Microsoft.EntityFrameworkCore;
using Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEditor.ViewModels;

namespace WebEditor.Services
{
    public interface IConfigurationService
    {
        Task<IEnumerable<ConfigurationListeItemViewModel>> ListConfigurations();
    }

    public class ConfigurationService : IConfigurationService
    {
        private readonly ConfigContext _context;

        public ConfigurationService(ConfigContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ConfigurationListeItemViewModel>> ListConfigurations()
        {
            var configurations = await _context.Configurations.Select(q => new ConfigurationListeItemViewModel()
            {
                ApplicationName = q.ApplicationName,
                Id = q.Id,
                IsActive = q.IsActive,
                Name = q.Name,
                Value = q.Value,
            }).ToListAsync();

            return configurations;
        }
    }
}
