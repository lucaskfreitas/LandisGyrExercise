using LandisGyrExercise.Enumerables;
using System;

namespace LandisGyrExercise.Model
{
    public class Endpoint
    {
        private readonly string _serialNumber;
        private int _meterModelId = 0;
        private int _switchState = 0;

        public string SerialNumber { get => _serialNumber; }
        public MeterModel MeterModelId
        {
            get => (MeterModel)_meterModelId;
            set
            {
                if (!Enum.IsDefined(typeof(MeterModel), value))
                    throw new InvalidCastException();

                _meterModelId = (int)value;
            }
        }
        public int MeterNumber { get; set; }
        public string MeterFirmwareVersion { get; set; }
        public SwitchState SwitchState
        {
            get => (SwitchState)_switchState;
            set
            {
                if (!Enum.IsDefined(typeof(SwitchState), value))
                    throw new InvalidCastException();

                _switchState = (int)value;
            }
        }

        public Endpoint(string serialNumber)
        {
            _serialNumber = serialNumber;
        }
    }
}
