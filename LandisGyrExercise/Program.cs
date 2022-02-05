using LandisGyrExercise.Controller;
using LandisGyrExercise.EndpointRepository;
using LandisGyrExercise.UserInterface;

namespace LandisGyrExercise
{
    class Program
    {
        static void Main()
        {
            var userInterface = new ConsoleInterface();
            var endpointDatabase = new EndpointMemoryDatabase();

            var controller = new MainController(userInterface, endpointDatabase);
            controller.Run();
        }
    }
}
