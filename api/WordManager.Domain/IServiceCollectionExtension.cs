using DP.CqsLite;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Wordmanager.Data;

namespace WordManager.Domain {
  public static class IServiceCollectionExtension {

    public static IServiceCollection AddCQS(this IServiceCollection services) {

      //services.AddTransient(typeof(IQueryHandler<GetAllGraduationsQuery, IQueryable<GraduationDTO>>), typeof(GetAllGraduationsQueryHandler));
      //services.AddTransient(typeof(IQueryHandler<GetCurriculumByGraduationAndLanguageQuery, GetCurriculumByGraduationAndLanguageQueryResult>), typeof(GetCurriculumByGraduationAndLanguageQueryHandler));
      services.Scan(Assembly.GetExecutingAssembly(), typeof(IQueryHandler<,>), ServiceLifetime.Transient);
      services.AddSQLite();

      return services;
    }

    // Source https://stackoverflow.com/questions/49087739/net-core-register-raw-generic-with-different-number-of-parameters
    /// <summary>
    /// Extension method that allows you to pick an an interface (whether generic or non-generic)
    /// and all implementations of that interface will be registered for the provided assembly.
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="assembly"></param>
    /// <param name="serviceType"></param>
    /// <param name="lifetime"></param>
    /// <returns></returns>
    public static IServiceCollection Scan(
       this IServiceCollection serviceCollection,
       Assembly assembly,
       Type serviceType,
       ServiceLifetime lifetime) {
      return Scan(serviceCollection, new Assembly[] { assembly }, serviceType, lifetime);
    }


    /// <summary>
    /// Extension method that allows you to pick an an interface (whether generic or non-generic)
    /// and all implementations of that interface will be registered for the provided assembly.
    /// </summary>
    /// <typeparam name="Tservice"></typeparam>
    /// <param name="serviceCollection"></param>
    /// <param name="assembly"></param>
    /// <param name="lifetime"></param>
    /// <returns></returns>
    public static IServiceCollection Scan<Tservice>(
        this IServiceCollection serviceCollection,
        Assembly assembly,
        ServiceLifetime lifetime) {
      return Scan(serviceCollection, new Assembly[] { assembly }, typeof(Tservice), lifetime);
    }


    /// <summary>
    /// Extension method that allows you to pick an an interface (whether generic or non-generic)
    /// and all implementations of that interface will be registered for all of the provided assemblies.
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="assembly"></param>
    /// <param name="serviceType"></param>
    /// <param name="lifetime"></param>
    /// <returns></returns>
    public static IServiceCollection Scan(
        this IServiceCollection serviceCollection,
        IEnumerable<Assembly> assemblies,
        Type interfaceType,
        ServiceLifetime lifetime) {
      foreach (var type in assemblies.SelectMany(x =>
          x.GetTypes().Where(t => t.IsClass && !t.IsAbstract))) {
        foreach (var i in type.GetInterfaces()) {
          // Check for generic
          if (i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType) {
            var genericInterfaceType = interfaceType.MakeGenericType(i.GetGenericArguments());
            serviceCollection.Add(new ServiceDescriptor(genericInterfaceType, type, lifetime));
          }
          // Check for non-generic
          else if (!i.IsGenericType && i == interfaceType) {
            serviceCollection.Add(new ServiceDescriptor(interfaceType, type, lifetime));
          }
        }
      }

      return serviceCollection;
    }

  }
}