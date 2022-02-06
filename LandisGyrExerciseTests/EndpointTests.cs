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
        public void MeterModelEnum()
        {
            Endpoint endpoint = new("ABCDE");

            endpoint.MeterModelId = (MeterModel)16;
            Assert.IsTrue(endpoint.MeterModelId == MeterModel.NSX1P2W);

            endpoint.MeterModelId = (MeterModel)17;
            Assert.IsTrue(endpoint.MeterModelId == MeterModel.NSX1P3W);

            endpoint.MeterModelId = (MeterModel)18;
            Assert.IsTrue(endpoint.MeterModelId == MeterModel.NSX2P3W);

            endpoint.MeterModelId = (MeterModel)19;
            Assert.IsTrue(endpoint.MeterModelId == MeterModel.NSX3P4W);

            Assert.ThrowsException<InvalidCastException>(() =>
            {
                endpoint.MeterModelId = (MeterModel)20;
            });
        }

        [TestMethod]
        public void SwitchStateEnum()
        {
            Endpoint endpoint = new("ABCDE");

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
