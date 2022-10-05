namespace VehicleTrackerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VehicleTracker_Constructor()
        {
            // arrange
            int capacity = 3;
            string address = "130 Henlow Bay";
            Dictionary<int, Vehicle> assertedVehicleList = new Dictionary<int, Vehicle>
            {
                {1, null},
                {2, null},
                {3, null},
            };



            // act
            VehicleTracker tracker = new VehicleTracker(capacity, address);
            Dictionary<int, Vehicle> vehicleList = tracker.VehicleList;

            // assert
            Assert.AreEqual(assertedVehicleList,
                vehicleList);
        }
    }
}