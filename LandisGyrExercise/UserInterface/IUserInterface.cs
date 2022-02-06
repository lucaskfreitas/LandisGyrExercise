using LandisGyrExercise.Controller;
using LandisGyrExercise.Enumerables;
using LandisGyrExercise.Model;

namespace LandisGyrExercise.UserInterface
{
    public interface IUserInterface
    {
        public void SetController(IController controller);
        public void Run();
        public void PrintEndpointData(Endpoint endpoint);
        public void AskUserForEndpointData(Endpoint newEndpoint);
        public string AskUserForSerialNumber();
        public SwitchState AskUserForSwitchState();
    }
}
