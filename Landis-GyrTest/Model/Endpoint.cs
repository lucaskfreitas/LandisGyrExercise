using LandisGyrTest.Enumerables;
using System;

namespace LandisGyrTest.Model
{
    public class Endpoint
    {
        private readonly string _serialNumber;
        private int _meterModelId = 0;
        private int _switchState;

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
                _switchState = (int)value;
            }
        }

        public Endpoint(string serialNumber)
        {
            _serialNumber = serialNumber;
            DetermineMeterModel();
        }

        public bool IsMeterModelSet()
        {
            return _meterModelId > 0;
        }

        private void DetermineMeterModel()
        {
            switch (_serialNumber)
            {
                case "NSX1P2W":
                    _meterModelId = 16;
                    break;

                case "NSX1P3W":
                    _meterModelId = 17;
                    break;

                case "NSX2P3W":
                    _meterModelId = 18;
                    break;

                case "NSX3P4W":
                    _meterModelId = 19;
                    break;
            }
        }
    }
}
