using LandisGyrExercise.Enumerables;
using LandisGyrExercise.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LandisGyrExerciseTests
{
    [TestClass]
    public class EndpointTests
    {
        [TestMethod]
        public void FixedMeterModel1()
        {
            Endpoint endpoint = new("NSX1P2W");
            Assert.AreEqual(16, endpoint.MeterModelId);
            Assert.ThrowsException<InvalidOperationException>(() => endpoint.MeterModelId = 1000);
        }

        [TestMethod]
        public void FixedMeterModel2()
        {
            Endpoint endpoint = new("NSX1P3W");
            Assert.AreEqual(17, endpoint.MeterModelId);
            Assert.ThrowsException<InvalidOperationException>(() => endpoint.MeterModelId = 1000);
        }

        [TestMethod]
        public void FixedMeterModel3()
        {
            Endpoint endpoint = new("NSX2P3W");
            Assert.AreEqual(18, endpoint.MeterModelId);
            Assert.ThrowsException<InvalidOperationException>(() => endpoint.MeterModelId = 1000);
        }

        [TestMethod]
        public void FixedMeterModel4()
        {
            Endpoint endpoint = new("NSX3P4W");
            Assert.AreEqual(19, endpoint.MeterModelId);
            Assert.ThrowsException<InvalidOperationException>(() => endpoint.MeterModelId = 1000);
        }

        [TestMethod]
        public void SwitchStateEnum()
        {
            Endpoint endpoint = new("NSX1P2W");

            endpoint.SwitchState = 0;
            Assert.IsTrue(endpoint.SwitchState == SwitchState.Disconnected);

            endpoint.SwitchState = (SwitchState)1;
            Assert.IsTrue(endpoint.SwitchState == SwitchState.Connected);

            endpoint.SwitchState = (SwitchState)2;
            Assert.IsTrue(endpoint.SwitchState == SwitchState.Armed);

            Assert.ThrowsException<InvalidCastException>(() =>
            {
                endpoint.SwitchState = (SwitchState) 3;
            });
        }
    }
}
