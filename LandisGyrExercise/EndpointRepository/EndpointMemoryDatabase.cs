using System.Collections.Generic;
using System.Data;
using System.Linq;
using LandisGyrExercise.Model;

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
                throw new KeyNotFoundException();

            return endpoint;
        }

        public IEnumerable<Endpoint> GetAllEndpoints()
        {
            return _endpoints;
        }

        public void DeleteEndpoint(Endpoint endpoint)
        {
            _endpoints.Remove(endpoint);
        }

        public void DeleteEndpoint(string serialNumber)
        {
            DeleteEndpoint(GetEndpoint(serialNumber));
        }
    }
}
