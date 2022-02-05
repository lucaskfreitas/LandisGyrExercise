using LandisGyrExercise.Model;
using LandisGyrExercise.Enumerables;
using System;

namespace LandisGyrExercise.UserInterface
{
    public interface IUserInterface
    {
        public UserAction QueryAction();

        public string QuerySerialNumber();
        public int QueryMeterModelId();
        public int QueryMeterNumber();
        public string QueryMeterFirmwareVersion();
        public SwitchState QuerySwitchState();

        public void PrintEndpointData(Endpoint endpoint);
        public void ShowError(Exception e);

        public bool ConfirmAction();
    }
}
