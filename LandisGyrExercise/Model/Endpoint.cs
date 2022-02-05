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
        public int MeterModelId
        {
            get => _meterModelId;
            set
            {
                if (IsMeterModelSet())
                    throw new InvalidOperationException("Value already set");

                _meterModelId = value;
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
            _meterModelId = DetermineMeterModel();
        }

        public bool IsMeterModelSet()
        {
            return _meterModelId > 0;
        }

        private int DetermineMeterModel()
        {
            return _serialNumber switch
            {
                "NSX1P2W" => 16,
                "NSX1P3W" => 17,
                "NSX2P3W" => 18,
                "NSX3P4W" => 19,
                _ => 0,
            };
        }
    }
}
