using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StartApp.Infrastructure.Contexts;

namespace StartApp.Ef.Migrator
{
    internal class MigratorDbContext : ServerDbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public MigratorDbContext(
            DbContextOptions options,
            ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
                
            builder.HasPostgresExtension("uuid-ossp");
                
            DataSeedingProvider.Config(builder);
        }
    }
}