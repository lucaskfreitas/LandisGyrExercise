using LandisGyrExercise.EndpointRepository;
using LandisGyrExercise.Model;
using LandisGyrExercise.Enumerables;
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
            _endpointRepository = endpointRepository;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    switch (_userInterface.QueryAction())
                    {
                        case UserAction.AddEndpoint:
                            AddEndpoint();
                            break;

                        case UserAction.EditEndpoint:
                            EditEndpoint();
                            break;

                        case UserAction.DeleteEndpoint:
                            DeleteEndpoint();
                            break;

                        case UserAction.ListAllEndpoints:
                            ListAllEndpoints();
                            break;

                        case UserAction.FindEndpointBySerialNumber:
                            FindEndpointBySerialNumber();
                            break;

                        case UserAction.Exit:
                            if (_userInterface.ConfirmAction())
                                return;
                            break;
                    }
                }
                catch (Exception e)
                {
                    _userInterface.ShowError(e);
                }
            }
        }

        private void AddEndpoint()
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

        private void EditEndpoint()
        {
            string serialNumber = _userInterface.QuerySerialNumber();
            Endpoint endpoint = _endpointRepository.GetEndpoint(serialNumber);

            endpoint.SwitchState = _userInterface.QuerySwitchState();
        }

        private void DeleteEndpoint()
        {
            _endpointRepository.DeleteEndpoint(_userInterface.QuerySerialNumber());
        }

        private void ListAllEndpoints()
        {
            foreach (Endpoint endpoint in _endpointRepository.GetAllEndpoints())
            {
                _userInterface.PrintEndpointData(endpoint);
            }
        }

        private void FindEndpointBySerialNumber()
        {
            string serialNumber = _userInterface.QuerySerialNumber();
            Endpoint endpoint = _endpointRepository.GetEndpoint(serialNumber);
            _userInterface.PrintEndpointData(endpoint);
        }
    }
}
