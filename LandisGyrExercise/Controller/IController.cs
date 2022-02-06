namespace LandisGyrExercise.Controller
{
    public interface IController
    {
        void AddEndpoint();
        void DeleteEndpoint();
        void EditEndpoint();
        void FindEndpointBySerialNumber();
        void ListAllEndpoints();
        void Run();
    }
}