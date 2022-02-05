using LandisGyrTest.Controller;
using LandisGyrTest.EndpointRepository;
using LandisGyrTest.UserInterface;

namespace LandisGyrTest
{
    class Program
    {
        static void Main()
        {
            var userInterface = new ConsoleInterface();
            var endpointDatabase = new EndpointMemoryDatabase();

            var controller = new MainController(userInterface, endpointDatabase);
            controller.Start();
        }
    }
}
