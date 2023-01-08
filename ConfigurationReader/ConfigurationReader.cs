using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationReader
{
    public class ConfigurationReader
    {
        private DateTime _lastReadDateTime;
        private List<Configuration> _configurations;

        private readonly string _applicationName;
        private readonly string _connectionString;
        private readonly int _refreshTimerIntervalInMs;

        public ConfigurationReader(string applicationName, string connectionString, int refreshTimerIntervalInMs)
        {
            _applicationName = applicationName;
            _connectionString = connectionString;
            _refreshTimerIntervalInMs = refreshTimerIntervalInMs;

            _configurations = new List<Configuration>();
        }

        private DbContextOptions GetConnectionOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), _connectionString).Options;
        }

        private async Task<List<Configuration>> ReadConfig()
        {
            try
            {
                using (ConfigContext configContext = new ConfigContext(GetConnectionOptions()))
                {
                    _configurations = await configContext.Configurations.Where(q => q.ApplicationName == _applicationName && q.IsActive).ToListAsync();
                    _lastReadDateTime = DateTime.Now;
                    return _configurations;
                }
            }
            catch (Exception ex)
            {
                return _configurations;
            }
        }

        public async Task<T> GetValueAsync<T>(string key)
        {
            // Cache expire check
            if (_lastReadDateTime.AddMilliseconds(_refreshTimerIntervalInMs) > DateTime.Now)
            {
                _configurations = await ReadConfig();
            }

            var record = _configurations.FirstOrDefault(q => q.Name == key);
            if (record == null)
            {
                return default(T);
            }
            else
            {
                return (T)Convert.ChangeType(record.Value, typeof(T));
            }
        }
    }
}
