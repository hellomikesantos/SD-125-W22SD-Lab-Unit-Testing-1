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
            tracker.VehicleList = new Dictionary<int, Vehicle>()
            {
                {1, null},
                {2, null},
                {3, null},
            };

            Dictionary<int, Vehicle> assertedVehicleList = new Dictionary<int, Vehicle>
            {
                {1, vehicle},
                {2, null},
                {3, null},
            };


            // act
            tracker.AddVehicle(vehicle);

            // assert
            Assert.AreEqual(assertedVehicleList,
                tracker.VehicleList);
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

            // act & assert
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                tracker.AddVehicle(vehicle);
            });
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
            Assert.AreEqual(assertedVehicleList,
                tracker.VehicleList);
        }

        [TestMethod]
        public void RemoveVehicle_ShouldThrowAnExceptionIfLicenseIsNotFound()
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

            // act & assert
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                tracker.RemoveVehicle("ghost");
            });
        }

        [TestMethod]
        public void RemoveVehicle_ShouldThrowAnExceptionIfSlotNumberIsNegative()
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

            // act & assert
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                tracker.RemoveVehicle(-3);
            });
        }

        [TestMethod]
        public void RemoveVehicle_ShouldThrowAnExceptionIfSlotNumberIsGreaterThanCapacity()
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

            // act & assert
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                tracker.RemoveVehicle(5);
            });
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
            Assert.AreEqual(assertedVehicleList,
                tracker.VehicleList);
        }

        [TestMethod]
        public void VehicleTracker_SlotsAvailable_WhenAddVehicleIsCalled()
        {
            // arrange & act
            int capacity = 3;
            string address = "130 Henlow Bay";
            string license = "NDL-8349";
            bool pass = false;
            Vehicle vehicle = new Vehicle(license, pass);
            VehicleTracker tracker = new VehicleTracker(capacity, address);
            Dictionary<int, Vehicle> vehicleList = new Dictionary<int, Vehicle>
            {
                {1, null},
                {2, null},
                {3, null},
            };
            tracker.VehicleList = vehicleList;
            tracker.AddVehicle(vehicle);

            int assertedSlotsAvailable = 1;

            // assert
            Assert.AreEqual(assertedSlotsAvailable,
                tracker.SlotsAvailable);
        }

        [TestMethod]
        public void VehicleTracker_SlotsAvailable_WhenRemoveVehicleIsCalledUsingSlotNumber()
        {
            // arrange & act
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
            tracker.RemoveVehicle(1);

            int assertedSlotsAvailable = 0;

            // assert
            Assert.AreEqual(assertedSlotsAvailable,
                tracker.SlotsAvailable);
        }

        [TestMethod]
        public void VehicleTracker_SlotsAvailable_WhenRemoveVehicleIsCalledUsingLicense()
        {
            // arrange & act
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
            tracker.RemoveVehicle("NDL-8349");

            int assertedSlotsAvailable = 0;

            // assert
            Assert.AreEqual(assertedSlotsAvailable,
                tracker.SlotsAvailable);
        }

        [TestMethod]
        public void VehicleTracker_SlotsAvailable_WhenGenerateSlotsIsCalled()
        {
            // arrange & act
            int capacity = 3;
            string address = "130 Henlow Bay";
            VehicleTracker tracker = new VehicleTracker(capacity, address); // invokes GenerateSlots()

            int assertedSlotsAvailable = 1;

            // assert
            Assert.AreEqual(assertedSlotsAvailable,
                tracker.SlotsAvailable);
        }

        [TestMethod]
        public void ParkedPassholders()
        {
            // arrange & act
            int capacity = 3;
            string address = "130 Henlow Bay";
            string license = "NDL-8349";
            bool pass = false;
            Vehicle vehicle = new Vehicle(license, pass);
            Vehicle vehicle2 = new Vehicle("ABC-222", true);
            Vehicle vehicle3 = new Vehicle("QWE-102", true);
            VehicleTracker tracker = new VehicleTracker(capacity, address);
            Dictionary<int, Vehicle> vehicleList = new Dictionary<int, Vehicle>
            {
                {1, vehicle},
                {2, vehicle2},
                {3, vehicle3},
            };
            tracker.VehicleList = vehicleList;

            List<Vehicle> parkedPassholders = tracker.ParkedPassholders();
            List<Vehicle> assertedParkedPassholders = new List<Vehicle>()
            {
                vehicle2,
                vehicle3
            };

            // assert
            Assert.AreEqual(assertedParkedPassholders,
                parkedPassholders);
        }

        [TestMethod]
        public void PassholderPercentage()
        {
            // arrange & act
            int capacity = 3;
            string address = "130 Henlow Bay";
            VehicleTracker tracker = new VehicleTracker(capacity, address);

            string license = "NDL-8349";
            bool pass = false;
            Vehicle vehicle = new Vehicle(license, pass);
            Vehicle vehicle2 = new Vehicle("ABC-222", true);
            Vehicle vehicle3 = new Vehicle("QWE-102", true);
            Dictionary<int, Vehicle> vehicleList = new Dictionary<int, Vehicle>
            {
                {1, vehicle},
                {2, vehicle2},
                {3, vehicle3},
            };
            tracker.VehicleList = vehicleList;
            List<Vehicle> parkedPassholders = tracker.ParkedPassholders();

            int percentage = tracker.PassholderPercentage();
            int assertedPercentage = (int)66.66;

            // assert
            Assert.AreEqual(assertedPercentage,
                percentage);
        }

    }
}