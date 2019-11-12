using gRPC.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ClientConsole
{
    public class Startup
    {
        private ServiceProvider ServiceProvier { get; }

        public IServiceScope Scope => ServiceProvier.CreateScope();

        public Startup()
        {
            //setup our DI
            var servicesBuilder = new ServiceCollection()
                .AddLogging(config =>
                {
                    config.AddConsole();
                    config.AddDebug();
                });

            ConfigureServices(servicesBuilder);
            ServiceProvier = servicesBuilder.BuildServiceProvider();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGreterClient();
        }
    }
}