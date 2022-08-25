using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CarNS;

namespace CarTests
{
    [TestClass]
    public class CarTests
    {
        private Car testCar;
        private const int testGasTankSize = 10;
        private const double testMilesPerGallon = 50d;

        [TestInitialize]
        public void CreateTestCar()
        {
            testCar = new Car("Toyota", "Prius", testGasTankSize, testMilesPerGallon);
        }

        //[TestMethod]
        //public void EmptyTest()
        //{
        //Assert.AreEqual(10, 10, 0.001d);
        //}

        [TestMethod]
        public void TestInitialGasTankSize()
        {
            Assert.AreEqual(testCar.GasTankSize, testGasTankSize, 0.001d);
        }

        [TestMethod]
        public void TestInitialGasLevel()
        {
            Assert.AreEqual(testCar.GasTankSize, testCar.GasTankLevel, 0.001d);
        }

        [TestMethod]
        public void TestGasLevelAfterDriveInRange()
        {
            testCar.Drive(testMilesPerGallon);
            Assert.AreEqual(testCar.GasTankLevel, testGasTankSize - 1d, 0.001d);
        }

        [TestMethod]
        public void TestGasLevelAfterDriveAttemptOutOfRange()
        {
            double maxRange = testMilesPerGallon * testGasTankSize;
            testCar.Drive(maxRange + 10d);
            Assert.AreEqual(testCar.GasTankLevel, 0d, 0.001d);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestExceptionMoreGasThanTankSize()
        {
            testCar.AddGas(10d);
            Assert.Fail("Cannot have more gas than tank capacity!");
        }

    }
}
