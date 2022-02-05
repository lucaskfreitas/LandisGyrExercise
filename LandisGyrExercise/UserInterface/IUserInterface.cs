using LandisGyrExercise.Controller;
using LandisGyrExercise.Enumerables;
using LandisGyrExercise.Model;

namespace LandisGyrExercise.UserInterface
{
    public interface IUserInterface
    {
        public void SetController(MainController controller);
        public void Run();

        public string QuerySerialNumber();
        public int QueryMeterModelId();
        public int QueryMeterNumber();
        public string QueryMeterFirmwareVersion();
        public SwitchState QuerySwitchState();

        public void PrintEndpointData(Endpoint endpoint);
    }
}
