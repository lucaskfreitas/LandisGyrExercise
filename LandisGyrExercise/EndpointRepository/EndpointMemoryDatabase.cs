using LandisGyrExercise.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LandisGyrExercise.EndpointRepository
{
    public class EndpointMemoryDatabase : IEndpointRepository
    {
        private readonly List<Endpoint> _endpoints = new();

        public void AddEndpoint(Endpoint newEndpoint)
        {
            if (ExistsEndpoint(newEndpoint.SerialNumber))
                throw new DuplicateNameException("There is another endpoint with the same serial number.");

            _endpoints.Add(newEndpoint);
        }

        public bool ExistsEndpoint(string serialNumber)
        {
            return _endpoints.Any(t => t.SerialNumber == serialNumber);
        }

        public Endpoint GetEndpoint(string serialNumber)
        {
            Endpoint endpoint = _endpoints.SingleOrDefault(t => t.SerialNumber == serialNumber);

            if (endpoint == default)
                throw new KeyNotFoundException("There is no endpoint with this serial number");

            return endpoint;
        }

        public IEnumerable<Endpoint> GetAllEndpoints()
        {
            return _endpoints;
        }

        public void DeleteEndpoint(string serialNumber)
        {
            _endpoints.Remove(GetEndpoint(serialNumber));
        }
    }
}
