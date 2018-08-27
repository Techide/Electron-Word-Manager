using Microsoft.Extensions.DependencyInjection;
using Wordmanager.Data.Models;

namespace Wordmanager.Data {
  public static class IServiceCollectionExtension {

    public static IServiceCollection AddSQLite(this IServiceCollection services) {

      services.AddDbContext<WordManagerContext>(ServiceLifetime.Transient);

      return services;
    }

  }
}
