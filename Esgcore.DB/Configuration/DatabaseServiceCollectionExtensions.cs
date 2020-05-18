using Esgcore.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Esgcore.DB.Configuration
{
    public static class DatabaseServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string dbConnectionString)
        {
            services.AddDbContext<EsgcoreDbContext>(o => o.UseSqlServer(dbConnectionString));
            return services;
        }
    }
}
