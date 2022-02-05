using LandisGyrTest.Model;
using System.Collections.Generic;

namespace LandisGyrTest.EndpointRepository
{
    public interface IEndpointRepository
    {
        public void AddEndpoint(Endpoint newEndpoint);
        public bool ExistsEndpoint(string serialNumber);
        public Endpoint GetEndpoint(string serialNumber);
        public IEnumerable<Endpoint> GetAllEndpoints();
        public void DeleteEndpoint(Endpoint endpoint);
        public void DeleteEndpoint(string serialNumber);
    }
}
