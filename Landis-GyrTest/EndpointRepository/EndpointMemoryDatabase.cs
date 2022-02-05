using System.Collections.Generic;
using System.Linq;
using LandisGyrExercise.Model;

namespace LandisGyrExercise.EndpointRepository
{
    public class EndpointMemoryDatabase : IEndpointRepository
    {
        private readonly List<Endpoint> _endpoints = new();

        public void AddEndpoint(Endpoint newEndpoint)
        {
            _endpoints.Add(newEndpoint);
        }

        public bool ExistsEndpoint(string serialNumber)
        {
            return _endpoints.Any(t => t.SerialNumber == serialNumber);
        }

        public Endpoint GetEndpoint(string serialNumber)
        {
            return _endpoints.SingleOrDefault(t => t.SerialNumber == serialNumber);
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
