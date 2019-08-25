using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Data.ADO;
using CarDealership.Models.Tables;
using System.Data.SqlClient;
using System.Configuration;

namespace CarDealershipTests.IntegrationTests
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        public void init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
            }
        }
        [Test]
        public void CanLoadState()
        {
            var repo = new StateRepositoryADO();
            var states = repo.GetAll();

            Assert.AreEqual("MN", states[0].StateId);
        }

        [Test]
        public void CanLoadMake()
        {
            var repo = new MakeRepositoryADO();
            var makes = repo.GetAll();

            Assert.AreEqual(3, makes.Count);

            Assert.AreEqual(1, makes[0].MakeId);

            Assert.AreEqual("Jeep", makes[0].MakeName);
        }
        [Test]
        public void CanLoadVehicle()
        {
            var repo = new VehicleRepositoryADO();
            var vehicle = repo.GetById(1);

            Assert.IsNotNull(vehicle);
            Assert.AreEqual(1, vehicle.VehicleId);
            Assert.AreEqual("Leather", vehicle.Interior);
        }

        [Test]
        public void CanAddVehicle()
        {
            Vehicle vehicleToAdd = new Vehicle();
            var repo = new VehicleRepositoryADO();

            vehicleToAdd.Type = "USED";
            vehicleToAdd.BodyStyle = "SUV";

        }
        [Test]
        public void CanLoadDetails()
        {
            var repo = new VehicleRepositoryADO();
            var vehicle = repo.GetDetails(1);

            Assert.IsNotNull(vehicle);
            Assert.AreEqual(1, vehicle.VehicleId);
            Assert.AreEqual("2019", vehicle.Year);
            Assert.AreEqual("Automatic", vehicle.Transmission);
        }
    }
    
}
