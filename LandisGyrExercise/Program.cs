using LandisGyrExercise.Controller;
using LandisGyrExercise.EndpointRepository;
using LandisGyrExercise.UserInterface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LandisGyrExercise
{
    class Program
    {
        static void Main()
        {
            IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IController, MainController>()
                        .AddScoped<IUserInterface, ConsoleInterface>()
                        .AddScoped<IEndpointRepository, EndpointMemoryDatabase>();
                })
                .Build();

            MainController svc = ActivatorUtilities.CreateInstance<MainController>(host.Services);
            svc.Run();
        }
    }
}
