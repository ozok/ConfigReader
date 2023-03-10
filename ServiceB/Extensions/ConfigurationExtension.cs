using ConfigurationReader;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ServiceB.Extensions
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection AddConfigurationReader(this IServiceCollection services, IConfiguration configuration)
        {
            var configurationConnectionString = configuration.GetValue<string>("CONNECTIONSTRING");
            var configurationApplicationName = configuration.GetValue<string>("APPLICATIONNAME");
            var configurationRefreshTimerIntervalInMs = configuration.GetValue<int>("REFRESHTIMERINTERVALINMS");

            services.AddSingleton(configReader => new ConfigurationReader.ConfigurationReader(configurationApplicationName, configurationConnectionString, configurationRefreshTimerIntervalInMs));
            return services;
        }
    }
}
