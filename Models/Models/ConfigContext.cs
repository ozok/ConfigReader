using Microsoft.EntityFrameworkCore;
using System;

namespace Models.Models
{
    public class ConfigContext : DbContext
    {
        public ConfigContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Configuration> Configurations { get; set; }
    }
}
