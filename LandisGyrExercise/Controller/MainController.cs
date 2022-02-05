using LandisGyrExercise.EndpointRepository;
using LandisGyrExercise.Model;
using LandisGyrExercise.UserInterface;
using System;

namespace LandisGyrExercise.Controller
{
    public class MainController
    {
        private readonly IUserInterface _userInterface;
        private readonly IEndpointRepository _endpointRepository;

        public MainController(IUserInterface userInterface, IEndpointRepository endpointRepository)
        {
            _userInterface = userInterface;
            _userInterface.SetController(this);

            _endpointRepository = endpointRepository;
        }

        public void Run()
        {
            _userInterface.Run();
        }

        public void AddEndpoint()
        {
            string serialNumber = _userInterface.QuerySerialNumber();
            if (_endpointRepository.ExistsEndpoint(serialNumber))
                throw new InvalidOperationException("This endpoint already exists");

            Endpoint endpoint = new(serialNumber);

            if (!endpoint.IsMeterModelSet())
                endpoint.MeterModelId = _userInterface.QueryMeterModelId();

            endpoint.MeterNumber = _userInterface.QueryMeterNumber();
            endpoint.MeterFirmwareVersion = _userInterface.QueryMeterFirmwareVersion();
            endpoint.SwitchState = _userInterface.QuerySwitchState();

            _endpointRepository.AddEndpoint(endpoint);
        }

        public void EditEndpoint()
        {
            string serialNumber = _userInterface.QuerySerialNumber();
            Endpoint endpoint = _endpointRepository.GetEndpoint(serialNumber);

            endpoint.SwitchState = _userInterface.QuerySwitchState();
        }

        public void DeleteEndpoint()
        {
            string serialNumber = _userInterface.QuerySerialNumber();

            if (!_endpointRepository.ExistsEndpoint(serialNumber))
                throw new InvalidOperationException("There is no endpoint with this serial number.");

            _endpointRepository.DeleteEndpoint(serialNumber);
        }

        public void ListAllEndpoints()
        {
            foreach (Endpoint endpoint in _endpointRepository.GetAllEndpoints())
            {
                _userInterface.PrintEndpointData(endpoint);
            }
        }

        public void FindEndpointBySerialNumber()
        {
            string serialNumber = _userInterface.QuerySerialNumber();
            Endpoint endpoint = _endpointRepository.GetEndpoint(serialNumber);
            _userInterface.PrintEndpointData(endpoint);
        }
    }
}
