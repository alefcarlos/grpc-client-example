using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static Api.Greeter;

namespace ClientConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // This switch must be set before creating the GrpcChannel/HttpClient.
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var startUp = new Startup();

            using (var scope = startUp.Scope)
            {
                var logger = startUp.Scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                logger.LogInformation("Starting ClientConsole");

                var client = startUp.Scope.ServiceProvider.GetRequiredService<GreeterClient>();
                var response = await client.SayHelloAsync(new Api.HelloRequest { Name = "Alef Carlos" });

                logger.LogInformation($"Response from grpcClient: {response.Message}");

                logger.LogInformation("ClientConsole is finalized");
            }
        }
    }
}
