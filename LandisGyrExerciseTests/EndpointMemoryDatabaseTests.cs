using LandisGyrExercise.EndpointRepository;
using LandisGyrExercise.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data;

namespace LandisGyrExerciseTests
{
    [TestClass]
    public class EndpointMemoryDatabaseTests
    {
        [TestMethod]
        public void EndpointsWithSameSerialNumber()
        {
            Endpoint firstEndpoint = new("Duplicated serial number");
            Endpoint secondEndpoint = new("Duplicated serial number");

            EndpointMemoryDatabase endpointDatabase = new();
            endpointDatabase.AddEndpoint(firstEndpoint);

            Assert.ThrowsException<DuplicateNameException>(() => endpointDatabase.AddEndpoint(secondEndpoint));
        }

        [TestMethod]
        public void GetEndpointWithInvalidSerialNumber()
        {
            EndpointMemoryDatabase endpointDatabase = new();
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                endpointDatabase.GetEndpoint("garbage serial number");
            });
        }

        [TestMethod]
        public void DeleteEndpointWithInvalidSerialNumber()
        {
            EndpointMemoryDatabase endpointDatabase = new();
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                endpointDatabase.DeleteEndpoint("garbage serial number");
            });
        }
    }
}
