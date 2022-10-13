using Microsoft.EntityFrameworkCore;
using Moq;

namespace VehicleTrackerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            // Mock data
            var dataVehicleTrackerList = new List<VehicleTracker>
            {
                new VehicleTracker(3, "123 Ave."),
                new VehicleTracker(4, "123 Ave."),
                new VehicleTracker(5, "123 Ave."),
                new VehicleTracker(6, "123 Ave."),
                new VehicleTracker(7, "123 Ave."),
            }.AsQueryable();

            var dataVehicleList = new List<Vehicle>
            {
                new Vehicle("asd", false),
                new Vehicle("qwe", false),
                new Vehicle("zxc", false),
                new Vehicle("123", false),
                new Vehicle("jkl", false),
            }.AsQueryable();

            // Mock dBSet
            var mockDbSetVehicleTracker = new Mock<DbSet<VehicleTracker>>();
            var mockDbSetVehicle = new Mock<DbSet<Vehicle>>();

            // hook up data to dBSet of VehicleTracker
            mockDbSetVehicleTracker.As<IQueryable<VehicleTracker>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSetVehicleTracker.As<IQueryable<VehicleTracker>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSetVehicleTracker.As<IQueryable<VehicleTracker>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSetVehicleTracker.As<IQueryable<VehicleTracker>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            // hook up data to dbSet of Vehicle
            mockDbSetVehicle.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSetVehicle.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSetVehicle.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSetVehicle.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);
        }
        [TestMethod]
        public void VehicleTracker_Constructor()
        {
            // arrange & act

            Dictionary<int, Vehicle> assertedVehicleList = new Dictionary<int, Vehicle>();
            int assertedSlotsAvailable = 3;

            VehicleTracker tracker = new VehicleTracker(3, "HenlowBay");


            // assert
            Assert.AreEqual(assertedSlotsAvailable,
                tracker.SlotsAvailable);
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

            VehicleTracker assertedTracker = new VehicleTracker(capacity, address);
            assertedTracker.VehicleList[1] = vehicle;
            assertedTracker.SlotsAvailable = 2;

            // act
            tracker.AddVehicle(vehicle);

            // assert
            Assert.AreEqual(assertedTracker.SlotsAvailable,
                tracker.SlotsAvailable);
        }

        [TestMethod]
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
            tracker.VehicleList[1] = vehicle;
            tracker.VehicleList[2] = vehicle2;
            tracker.VehicleList[3] = vehicle3;


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
            tracker.AddVehicle(vehicle);
            
            VehicleTracker assertedTracker = new VehicleTracker(capacity, address);

            // act
            tracker.RemoveVehicle(1);

            // assert
            Assert.AreEqual(assertedTracker.SlotsAvailable,
                tracker.SlotsAvailable); ;
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
            tracker.AddVehicle(vehicle);


            // act & assert
            Assert.ThrowsException<Exception>(() =>
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
            tracker.VehicleList[1] = vehicle;

            // act & assert
            Assert.ThrowsException<Exception>(() =>
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
            tracker.AddVehicle(vehicle);
            VehicleTracker assertedTracker = new VehicleTracker(capacity, address);
            

            // act
            tracker.RemoveVehicle(license);

            // assert
            Assert.AreEqual(assertedTracker.SlotsAvailable,
                tracker.SlotsAvailable);
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

            tracker.AddVehicle(vehicle);

            int assertedSlotsAvailable = 2;

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
            tracker.AddVehicle(vehicle);
            
            tracker.RemoveVehicle(1);

            int assertedSlotsAvailable = 3;

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
            tracker.AddVehicle(vehicle);

            tracker.RemoveVehicle("NDL-8349");

            int assertedSlotsAvailable = 3;

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

            int assertedSlotsAvailable = 3;

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
            tracker.AddVehicle(vehicle);
            tracker.AddVehicle(vehicle2);
            tracker.AddVehicle(vehicle3);



            List<Vehicle> assertedParkedPassholders = new List<Vehicle>()
            {
                vehicle2,
                vehicle3
            };

            // assert
            Assert.AreEqual(assertedParkedPassholders.Count(),
                tracker.ParkedPassholders().Count());
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
            tracker.AddVehicle(vehicle);
            tracker.AddVehicle(vehicle2);
            tracker.AddVehicle(vehicle3);

            int percentage = tracker.PassholderPercentage();
            int assertedPercentage = (2 / 3) * 100;

            // assert
            Assert.AreEqual(assertedPercentage,
                percentage);
        }

    }
}