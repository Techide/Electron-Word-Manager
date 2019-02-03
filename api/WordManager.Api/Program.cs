using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using WordManager.Domain;

namespace WordManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            DomainInitiator.Initiate();
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
