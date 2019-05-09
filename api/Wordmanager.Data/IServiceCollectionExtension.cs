using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Wordmanager.Data
{
    public static class IServiceCollectionExtension
    {

        public static IServiceCollection AddSQLite(this IServiceCollection services)
        {
            string connectionString = "Data Source = WordManagerDataBase.db";
            services.AddDbContext<WordManagerContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlite(connectionString, options => { options.MigrationsAssembly("WordManager.Api"); });
            }, ServiceLifetime.Scoped);

            return services;
        }

    }
}
