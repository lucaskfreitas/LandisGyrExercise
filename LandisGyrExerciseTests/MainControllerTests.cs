using LandisGyrExercise.Controller;
using LandisGyrExercise.EndpointRepository;
using LandisGyrExercise.Enumerables;
using LandisGyrExercise.Model;
using LandisGyrExercise.UserInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LandisGyrExerciseTests
{
    [TestClass]
    public class MainControllerTests
    {
        [TestMethod]
        public void EditEndpointFeature()
        {
            string endpointSerialNumber = "TEST";

            //Creating user interface
            Mock<IUserInterface> mockInterface = new();
            mockInterface.Setup(t => t.AskUserForSerialNumber()).Returns(endpointSerialNumber);
            mockInterface.Setup(t => t.AskUserForSwitchState()).Returns(SwitchState.Armed);

            //Creating endpoint database with a single endpoint
            Endpoint endpoint = new(endpointSerialNumber);
            endpoint.SwitchState = SwitchState.Disconnected;
            EndpointMemoryDatabase endpointDatabase = new();
            endpointDatabase.AddEndpoint(endpoint);

            //Creating controller
            MainController controller = new(mockInterface.Object, endpointDatabase);

            //Verifying if "EditEndpoint" method correctly changes the SwitchState to Armed.
            Assert.AreNotEqual(endpoint.SwitchState, SwitchState.Armed);
            controller.EditEndpoint();
            Assert.AreEqual(endpoint.SwitchState, SwitchState.Armed);
        }
    }
}
