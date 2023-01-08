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
        Task<IEnumerable<ConfigurationListItemViewModel>> ListConfigurations();
        Task<ConfigurationEditViewModel> GetConfigurationEditViewModel(int configId);
        Task<ConfigurationEditViewModel> EditConfiguration(ConfigurationEditViewModel model);
    }

    public class ConfigurationService : IConfigurationService
    {
        private readonly ConfigContext _context;

        public ConfigurationService(ConfigContext context)
        {
            _context = context;
        }

        public async Task<ConfigurationEditViewModel> EditConfiguration(ConfigurationEditViewModel model)
        {
            var config = await _context.Configurations.FirstOrDefaultAsync(q => q.Id == model.Id);
            if (config == null)
            {
                return null;
            }

            config.ApplicationName = model.ApplicationName;
            config.IsActive = model.IsActive;   
            config.Name = model.Name;
            config.Value = model.Value;
            
            await _context.SaveChangesAsync();

            return await GetConfigurationEditViewModel(model.Id);
        }

        public async Task<ConfigurationEditViewModel> GetConfigurationEditViewModel(int configId)
        {
            var model = await _context.Configurations.FirstOrDefaultAsync(q => q.Id == configId);
            return new ConfigurationEditViewModel()
            {
                Id = configId,
                ApplicationName = model.ApplicationName,
                IsActive = model.IsActive,
                Name = model.Name,
                Value = model.Value
            };
        }

        public async Task<IEnumerable<ConfigurationListItemViewModel>> ListConfigurations()
        {
            var configurations = await _context.Configurations.Select(q => new ConfigurationListItemViewModel()
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
