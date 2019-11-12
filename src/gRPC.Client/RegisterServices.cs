using System;
using Microsoft.Extensions.DependencyInjection;
using static Api.Greeter;

namespace gRPC.Client
{
    public static class RegisterServices
    {

        public static IHttpClientBuilder AddGreterClient(this IServiceCollection services)
        {
            return services.AddGrpcClient<GreeterClient>(o =>
                {
                    o.Address = new Uri("http://localhost:5000");
                });
        }
    }
}
