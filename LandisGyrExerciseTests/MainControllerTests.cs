using LandisGyrExercise.Controller;
using LandisGyrExercise.EndpointRepository;
using LandisGyrExercise.Enumerables;
using LandisGyrExercise.Model;
using LandisGyrExercise.UserInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace LandisGyrExerciseTests
{
    [TestClass]
    public class MainControllerTests
    {
        //[TestMethod]
        public void TestAddEndpoint()
        {
            /*Mock<IUserInterface> mock = new();
            mock.Setup(t => t.QueryMeterFirmwareVersion()).Returns("1.2.3");
            mock.Setup(t => t.QueryMeterModelId()).Returns(1000);
            mock.Setup(t => t.QueryMeterNumber()).Returns(1000);
            mock.Setup(t => t.QuerySerialNumber()).Returns("NSX1P2W");
            mock.Setup(t => t.QuerySwitchState()).Returns(SwitchState.Connected);

            EndpointMemoryDatabase endpointDatabase = new();

            MainController controller = new(mock.Object, endpointDatabase);
            controller.AddEndpoint();

            IEnumerable<Endpoint> endpointList = endpointDatabase.GetAllEndpoints();
            Assert.IsTrue(endpointList.Count() == 1);
            Assert.IsTrue(endpointList.SingleOrDefault().SerialNumber == "NSX1P2W");
            Assert.IsTrue(endpointList.SingleOrDefault().MeterModelId == 16);*/
        }
    }
}
