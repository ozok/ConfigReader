using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Models;
using System;

namespace ServiceA.Extensions
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection AddConfigurationReader(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            var configurationConnectionString = configurationSection.GetValue<string>("ConnectionString");
            var configurationApplicationName = configurationSection.GetValue<string>("ApplicationName");
            var configurationRefreshTimerIntervalInMs = configurationSection.GetValue<int>("RefreshTimerIntervalInMs");

            services.AddSingleton(configReader => new ConfigurationReader.ConfigurationReader(configurationApplicationName, configurationConnectionString, configurationRefreshTimerIntervalInMs));
            return services;
        }
    }
}
