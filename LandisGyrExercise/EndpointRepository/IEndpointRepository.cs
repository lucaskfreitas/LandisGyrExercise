using LandisGyrExercise.Model;
using System.Collections.Generic;

namespace LandisGyrExercise.EndpointRepository
{
    public interface IEndpointRepository
    {
        public void AddEndpoint(Endpoint newEndpoint);
        public bool ExistsEndpoint(string serialNumber);
        public Endpoint GetEndpoint(string serialNumber);
        public IEnumerable<Endpoint> GetAllEndpoints();
        public void DeleteEndpoint(string serialNumber);
    }
}
