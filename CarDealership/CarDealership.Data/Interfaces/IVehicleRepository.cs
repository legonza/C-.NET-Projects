using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IVehicleRepository
    {
        Vehicle GetById(int VehicleId);
        void Insert(Vehicle vehicle);
        void Purchased(Purchase purchase);
        void InsertSpecial(Specials special);
        void Update(Vehicle vehicle);
        void Delete(int vehicleId);
        void DeleteSpecial(int specialsId);
        IEnumerable<InventoryReport> Reports(string vehicleType);
        IEnumerable<FeaturedVehicles> GetFeatured();
        VehicleItem GetDetails(int vehicleId);
        IEnumerable<AllSpecials>SpecialById();
        IEnumerable<AllVehicles> VehicleList();
        IEnumerable<VehicleShortItem> Search(VehicleSearchParameters parameters);
        IEnumerable<VehicleShortItem> UsedSearch(UsedVehicleSearchParameters parameters);
        IEnumerable<VehicleShortItem> SalesSearch(SalesVehicleSearchParameters parameters);
        IEnumerable<VehicleShortItem> AdminSearch(AdminVehicleSearchParameters parameters);
    }
}
