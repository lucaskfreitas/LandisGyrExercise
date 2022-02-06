namespace LandisGyrExercise.Controller
{
    public interface IController
    {
        public void Run();
        public void AddEndpoint();
        public void DeleteEndpoint();
        public void EditEndpoint();
        public void FindEndpointBySerialNumber();
        public void ListAllEndpoints();
    }
}