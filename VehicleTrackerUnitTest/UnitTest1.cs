namespace VehicleTrackerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VehicleTracker_Constructor()
        {
            // arrange & act
            int capacity = 3;
            string address = "130 Henlow Bay";
            Dictionary<int, Vehicle> assertedVehicleList = new Dictionary<int, Vehicle>
            {
                {1, null},
                {2, null},
                {3, null},
            };

            VehicleTracker tracker = new VehicleTracker(capacity, address);
            Dictionary<int, Vehicle> vehicleList = tracker.VehicleList;

            // assert
            Assert.AreEqual(assertedVehicleList,
                vehicleList);
        }

        [TestMethod]
        public void AddVehicle()
        {
            // arrange
            int capacity = 3;
            string address = "130 Henlow Bay";
            string license = "NDL-8349";
            bool pass = false;
            Vehicle vehicle = new Vehicle(license, pass);
            VehicleTracker tracker = new VehicleTracker(capacity, address);
            Dictionary<int, Vehicle> vehicleList = tracker.VehicleList;
            Dictionary<int, Vehicle> assertedVehicleList = new Dictionary<int, Vehicle>
            {
                {1, vehicle},
                {2, null},
                {3, null},
            };


            // act
            tracker.AddVehicle(vehicle);

            // assert
            Assert.AreEqual(tracker.VehicleList,
                assertedVehicleList);
        }

        public void AddVehicle_IfThereAreNoOpenSlots()
        {
            // arrange
            int capacity = 3;
            string address = "130 Henlow Bay";
            string license = "NDL-8349";
            bool pass = false;
            Vehicle vehicle = new Vehicle(license, pass);
            Vehicle vehicle2 = new Vehicle("ABC-124", false);
            Vehicle vehicle3 = new Vehicle("ZXC-555", false);
            VehicleTracker tracker = new VehicleTracker(capacity, address);
            Dictionary<int, Vehicle> vehicleList = tracker.VehicleList;
            Dictionary<int, Vehicle> assertedVehicleList = new Dictionary<int, Vehicle>
            {
                {1, vehicle},
                {2, vehicle2},
                {3, vehicle3},
            };

            // act
            tracker.AddVehicle(vehicle);

            // assert
            Assert.AreEqual(vehicleList,
                assertedVehicleList);
        }

        [TestMethod]
        public void RemoveVehicle_AcceptsInt()
        {
            // arrange
            int capacity = 3;
            string address = "130 Henlow Bay";
            string license = "NDL-8349";
            bool pass = false;
            Vehicle vehicle = new Vehicle(license, pass);
            VehicleTracker tracker = new VehicleTracker(capacity, address);
            Dictionary<int, Vehicle> vehicleList = new Dictionary<int, Vehicle>
            {
                {1, vehicle},
                {2, null},
                {3, null},
            };
            tracker.VehicleList = vehicleList;
            Dictionary<int, Vehicle> assertedVehicleList = new Dictionary<int, Vehicle>
            {
                {1, null},
                {2, null},
                {3, null},
            };

            // act
            tracker.RemoveVehicle(1);

            // assert
            Assert.AreEqual(tracker.VehicleList,
                assertedVehicleList);
        }

        [TestMethod]
        public void RemoveVehicle_AcceptsString()
        {
            // arrange
            int capacity = 3;
            string address = "130 Henlow Bay";
            string license = "NDL-8349";
            bool pass = false;
            Vehicle vehicle = new Vehicle(license, pass);
            VehicleTracker tracker = new VehicleTracker(capacity, address);
            Dictionary<int, Vehicle> vehicleList = new Dictionary<int, Vehicle>
            {
                {1, vehicle},
                {2, null},
                {3, null},
            };
            tracker.VehicleList = vehicleList;
            Dictionary<int, Vehicle> assertedVehicleList = new Dictionary<int, Vehicle>
            {
                {1, null},
                {2, null},
                {3, null},
            };

            // act
            tracker.RemoveVehicle(license);

            // assert
            Assert.AreEqual(tracker.VehicleList,
                assertedVehicleList);
        }

        [TestMethod]
        public void VehicleTracker_SlotsAvailable()
        {

        }

    }
}