using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADO
{
    public class VehicleRepositoryADO : IVehicleRepository
    {
        public IEnumerable<AllSpecials> SpecialById()
        {
            List<AllSpecials> specials = new List<AllSpecials>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        AllSpecials row = new AllSpecials();
                        row.SpecialsId = (int)dr["SpecialsId"];
                        row.Title = dr["Title"].ToString();
                        row.Description = dr["Description"].ToString();
                        if (dr["SpecialsImage"] != DBNull.Value)
                            row.SpecialsImage = dr["SpecialsImage"].ToString();
                        specials.Add(row);
                    }
                }
            }
            return specials;
        }

        public void InsertSpecial(Specials special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("SpecialsId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Title", special.Title);
                cmd.Parameters.AddWithValue("@Description", special.Description);
                if (string.IsNullOrEmpty(special.SpecialsImage))
                {
                    cmd.Parameters.AddWithValue("@SpecialsImage", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SpecialsImage", special.SpecialsImage);
                }
                
                cn.Open();
                cmd.ExecuteNonQuery();
                special.SpecialsId = (int)param.Value;
            }
        }
    

        public void Delete(int vehicleId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("VehicleId", vehicleId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSpecial(int specialsId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("SpecialsId", specialsId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Vehicle GetById(int VehicleId)
        {
            Vehicle vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("VehicleId", VehicleId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new Vehicle();
                        vehicle.VehicleId = (int)dr["VehicleId"];
                        vehicle.Type = dr["Type"].ToString();
                        vehicle.BodyStyle = dr["BodyStyle"].ToString();
                        vehicle.Year = dr["Year"].ToString();
                        vehicle.Transmission = dr["Transmission"].ToString();
                        vehicle.Color = dr["Color"].ToString();
                        vehicle.Interior = dr["Interior"].ToString();
                        vehicle.Miles = dr["Miles"].ToString();
                        vehicle.Vin = dr["Vin"].ToString();
                        vehicle.Price = (decimal)dr["Price"];
                        vehicle.Msrp = (decimal)dr["Msrp"];
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.Featured = (bool)dr["Featured"];
                        if (dr["ImageFileName"] != DBNull.Value)
                            vehicle.ImageFileName = dr["ImageFileName"].ToString();

                    }
                }
            }
            return vehicle;
        }

        public VehicleItem GetDetails(int vehicleId)
        {
            VehicleItem vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new VehicleItem();
                        vehicle.VehicleId = (int)dr["VehicleId"];
                        vehicle.Type = dr["Type"].ToString();
                        vehicle.BodyStyle = dr["BodyStyle"].ToString();
                        vehicle.Year = dr["Year"].ToString();
                        vehicle.Transmission = dr["Transmission"].ToString();
                        vehicle.Color = dr["Color"].ToString();
                        vehicle.Interior = dr["Interior"].ToString();
                        vehicle.Miles = dr["Miles"].ToString();
                        vehicle.Vin = dr["Vin"].ToString();
                        vehicle.Price = (decimal)dr["Price"];
                        vehicle.Msrp = (decimal)dr["Msrp"];
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.Featured = (bool)dr["Featured"];
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();

                        if (dr["ImageFileName"] != DBNull.Value)
                            vehicle.ImageFileName = dr["ImageFileName"].ToString();

                    }
                }
            }
            return vehicle;
        }

        public IEnumerable<FeaturedVehicles> GetFeatured()
        {
            List<FeaturedVehicles> vehicles = new List<FeaturedVehicles>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectFeatured", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FeaturedVehicles row = new FeaturedVehicles();

                        row.VehicleId = (int)dr["VehicleId"];
                        row.Year = dr["Year"].ToString();
                        row.Price = (decimal)dr["Price"];
                        //row.MakeId = (int)dr["MakeId"];
                        row.MakeName = dr["MakeName"].ToString();
                        //row.ModelId = (int)dr["ModelId"];
                        row.ModelName = dr["ModelName"].ToString();
                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();
                        vehicles.Add(row);
                    }
                }
            }
            return vehicles;
        }

        public void Insert(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("VehicleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Type", vehicle.Type);
                cmd.Parameters.AddWithValue("@BodyStyle", vehicle.BodyStyle);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@Transmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@Color", vehicle.Color);
                cmd.Parameters.AddWithValue("@Interior", vehicle.Interior);
                cmd.Parameters.AddWithValue("@Miles", vehicle.Miles);
                cmd.Parameters.AddWithValue("@Vin", vehicle.Vin);
                cmd.Parameters.AddWithValue("@Price", vehicle.Price);
                cmd.Parameters.AddWithValue("@Msrp", vehicle.Msrp);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@IsSold", vehicle.IsSold);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                if (string.IsNullOrEmpty(vehicle.ImageFileName))
                {
                    cmd.Parameters.AddWithValue("@ImageFileName", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ImageFileName", vehicle.ImageFileName);
                }
                cmd.Parameters.AddWithValue("@MakeId", vehicle.MakeId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cn.Open();
                cmd.ExecuteNonQuery();
                vehicle.VehicleId = (int)param.Value;
            }
        }

        public void Update(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("VehicleId", vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@Type", vehicle.Type);
                cmd.Parameters.AddWithValue("@BodyStyle", vehicle.BodyStyle);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@Transmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@Color", vehicle.Color);
                cmd.Parameters.AddWithValue("@Interior", vehicle.Interior);
                cmd.Parameters.AddWithValue("@Miles", vehicle.Miles);
                cmd.Parameters.AddWithValue("@Vin", vehicle.Vin);
                cmd.Parameters.AddWithValue("@Price", vehicle.Price);
                cmd.Parameters.AddWithValue("@Msrp", vehicle.Msrp);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                if (string.IsNullOrEmpty(vehicle.ImageFileName))
                {
                    cmd.Parameters.AddWithValue("@ImageFileName", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ImageFileName", vehicle.ImageFileName);
                }
                cmd.Parameters.AddWithValue("@MakeId", vehicle.MakeId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<VehicleShortItem> Search(VehicleSearchParameters parameters)
        {
            List<VehicleShortItem> vehicles = new List<VehicleShortItem>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 VehicleId, BodyStyle, Year, Transmission, Color, Interior, Miles, Type, Vin, Price, Msrp, " +
                    "ImageFileName, MakeName, ModelName FROM Vehicle INNER JOIN Make ON Vehicle.MakeId = Make.MakeId INNER JOIN Model ON " +
                    "Vehicle.ModelId = Model.ModelId WHERE Type='NEW' AND 1 = 1 ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;


                if (parameters.MinPrice.HasValue)
                {
                    query += "AND Price >= @MinPrice ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }
                if (parameters.MaxPrice.HasValue)
                {
                    query += "AND Price <= @MaxPrice ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }
                if (!string.IsNullOrEmpty(parameters.MinYear))
                {
                    query += "AND Year >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                }
                if (!string.IsNullOrEmpty(parameters.MaxYear))
                {
                    query += "AND Year <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);
                }
                if (!string.IsNullOrEmpty(parameters.MakeName))
                {
                    query += "AND MakeName = @MakeName ";
                    cmd.Parameters.AddWithValue("@MakeName", parameters.MakeName);
                }
                if (!string.IsNullOrEmpty(parameters.ModelName))
                {
                    query += "AND ModelName = @ModelName ";
                    cmd.Parameters.AddWithValue("@ModelName", parameters.ModelName);
                }
                if (!string.IsNullOrEmpty(parameters.Year))
                {
                    query += "AND Year = @Year ";
                    cmd.Parameters.AddWithValue("@Year", parameters.Year);
                }
                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleShortItem row = new VehicleShortItem();

                        row.VehicleId = (int)dr["VehicleId"];
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.Year = dr["Year"].ToString();
                        row.Transmission = dr["Transmission"].ToString();
                        row.Color = dr["Color"].ToString();
                        row.Interior = dr["Interior"].ToString();
                        row.Type = dr["Type"].ToString();
                        row.Vin = dr["Vin"].ToString();
                        row.Price = (decimal)dr["Price"];
                        row.Msrp = (decimal)dr["Msrp"];
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelName = dr["ModelName"].ToString();
                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();
                        vehicles.Add(row);
                    }
                }
            }
            return vehicles;
        }

        public IEnumerable<VehicleShortItem> UsedSearch(UsedVehicleSearchParameters parameters)
        {
            List<VehicleShortItem> vehicles = new List<VehicleShortItem>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 VehicleId, BodyStyle, Year, Transmission, Color, Interior, Miles, Type, Vin, Price, Msrp, " +
                    "ImageFileName, MakeName, ModelName FROM Vehicle INNER JOIN Make ON Vehicle.MakeId = Make.MakeId INNER JOIN Model ON " +
                    "Vehicle.ModelId = Model.ModelId WHERE Type='USED' AND 1 = 1 ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;


                if (parameters.UsedMinPrice.HasValue)
                {
                    query += "AND Price >= @UsedMinPrice ";
                    cmd.Parameters.AddWithValue("@UsedMinPrice", parameters.UsedMinPrice.Value);
                }
                if (parameters.UsedMaxPrice.HasValue)
                {
                    query += "AND Price <= @UsedMaxPrice ";
                    cmd.Parameters.AddWithValue("@UsedMaxPrice", parameters.UsedMaxPrice.Value);
                }
                if (!string.IsNullOrEmpty(parameters.UsedMinYear))
                {
                    query += "AND Year >= @UsedMinYear ";
                    cmd.Parameters.AddWithValue("@UsedMinYear", parameters.UsedMinYear);
                }
                if (!string.IsNullOrEmpty(parameters.UsedMaxYear))
                {
                    query += "AND Year <= @UsedMaxYear ";
                    cmd.Parameters.AddWithValue("@UsedMaxYear", parameters.UsedMaxYear);
                }
                if (!string.IsNullOrEmpty(parameters.UsedMakeName))
                {
                    query += "AND MakeName = @UsedMakeName ";
                    cmd.Parameters.AddWithValue("@UsedMakeName", parameters.UsedMakeName);
                }
                if (!string.IsNullOrEmpty(parameters.UsedModelName))
                {
                    query += "AND ModelName = @UsedModelName ";
                    cmd.Parameters.AddWithValue("@UsedModelName", parameters.UsedModelName);
                }
                if (!string.IsNullOrEmpty(parameters.UsedYear))
                {
                    query += "AND Year = @UsedYear ";
                    cmd.Parameters.AddWithValue("@UsedYear", parameters.UsedYear);
                }
                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleShortItem row = new VehicleShortItem();

                        row.VehicleId = (int)dr["VehicleId"];
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.Year = dr["Year"].ToString();
                        row.Transmission = dr["Transmission"].ToString();
                        row.Color = dr["Color"].ToString();
                        row.Interior = dr["Interior"].ToString();
                        row.Type = dr["Type"].ToString();
                        row.Vin = dr["Vin"].ToString();
                        row.Price = (decimal)dr["Price"];
                        row.Msrp = (decimal)dr["Msrp"];
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelName = dr["ModelName"].ToString();
                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();
                        vehicles.Add(row);
                    }
                }
            }
            return vehicles;
        }



        public IEnumerable<AllVehicles> VehicleList()
        {
            List<AllVehicles> vehicles = new List<AllVehicles>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        AllVehicles row = new AllVehicles();
                        row.VehicleId = (int)dr["VehicleId"];
                        row.Type = dr["Type"].ToString();
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.Year = dr["Year"].ToString();
                        row.Transmission = dr["Transmission"].ToString();
                        row.Color = dr["Color"].ToString();
                        row.Interior = dr["Interior"].ToString();
                        row.Miles = dr["Miles"].ToString();
                        row.Vin = dr["Vin"].ToString();
                        row.Price = (decimal)dr["Price"];
                        row.Msrp = (decimal)dr["Msrp"];
                        row.Description = dr["Description"].ToString();
                        row.ModelName = dr["ModelName"].ToString();
                        row.MakeName = dr["MakeName"].ToString();
                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();
                        vehicles.Add(row);
                    }
                }
            }
            return vehicles;
        }



        public IEnumerable<VehicleShortItem> SalesSearch(SalesVehicleSearchParameters parameters)
        {
            List<VehicleShortItem> vehicles = new List<VehicleShortItem>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 VehicleId, BodyStyle, Year, Transmission, Color, Interior, Miles, Type, Vin, Price, Msrp, " +
                    "IsSold, ImageFileName, MakeName, ModelName FROM Vehicle INNER JOIN Make ON Vehicle.MakeId = Make.MakeId INNER JOIN Model ON " +
                    "Vehicle.ModelId = Model.ModelId WHERE IsSold=0 AND 1 = 1 ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;


                if (parameters.SalesMinPrice.HasValue)
                {
                    query += "AND Price >= @SalesMinPrice ";
                    cmd.Parameters.AddWithValue("@SalesMinPrice", parameters.SalesMinPrice.Value);
                }
                if (parameters.SalesMaxPrice.HasValue)
                {
                    query += "AND Price <= @SalesMaxPrice ";
                    cmd.Parameters.AddWithValue("@SalesMaxPrice", parameters.SalesMaxPrice.Value);
                }
                if (!string.IsNullOrEmpty(parameters.SalesMinYear))
                {
                    query += "AND Year >= @SalesMinYear ";
                    cmd.Parameters.AddWithValue("@SalesMinYear", parameters.SalesMinYear);
                }
                if (!string.IsNullOrEmpty(parameters.SalesMaxYear))
                {
                    query += "AND Year <= @SalesMaxYear ";
                    cmd.Parameters.AddWithValue("@SalesMaxYear", parameters.SalesMaxYear);
                }
                if (!string.IsNullOrEmpty(parameters.SalesMakeName))
                {
                    query += "AND MakeName = @SalesMakeName ";
                    cmd.Parameters.AddWithValue("@SalesMakeName", parameters.SalesMakeName);
                }
                if (!string.IsNullOrEmpty(parameters.SalesModelName))
                {
                    query += "AND ModelName = @SalesModelName ";
                    cmd.Parameters.AddWithValue("@SalesModelName", parameters.SalesModelName);
                }
                if (!string.IsNullOrEmpty(parameters.SalesYear))
                {
                    query += "AND Year = @SalesYear ";
                    cmd.Parameters.AddWithValue("@SalesYear", parameters.SalesYear);
                }
                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleShortItem row = new VehicleShortItem();

                        row.VehicleId = (int)dr["VehicleId"];
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.Year = dr["Year"].ToString();
                        row.Transmission = dr["Transmission"].ToString();
                        row.Color = dr["Color"].ToString();
                        row.Interior = dr["Interior"].ToString();
                        row.Type = dr["Type"].ToString();
                        row.Vin = dr["Vin"].ToString();
                        row.Price = (decimal)dr["Price"];
                        row.Msrp = (decimal)dr["Msrp"];
                        row.IsSold = (bool)dr["IsSold"];
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelName = dr["ModelName"].ToString();
                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();
                        vehicles.Add(row);
                    }
                }
            }
            return vehicles;
        }

        public IEnumerable<VehicleShortItem> AdminSearch(AdminVehicleSearchParameters parameters)
        {
            List<VehicleShortItem> vehicles = new List<VehicleShortItem>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 VehicleId, BodyStyle, Year, Transmission, Color, Interior, Miles, Type, Vin, Price, Msrp, " +
                    "IsSold, ImageFileName, MakeName, ModelName FROM Vehicle INNER JOIN Make ON Vehicle.MakeId = Make.MakeId INNER JOIN Model ON " +
                    "Vehicle.ModelId = Model.ModelId WHERE IsSold=0 AND 1 = 1 ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;


                if (parameters.AdminMinPrice.HasValue)
                {
                    query += "AND Price >= @AdminMinPrice ";
                    cmd.Parameters.AddWithValue("@AdminMinPrice", parameters.AdminMinPrice.Value);
                }
                if (parameters.AdminMaxPrice.HasValue)
                {
                    query += "AND Price <= @AdminMaxPrice ";
                    cmd.Parameters.AddWithValue("@AdminMaxPrice", parameters.AdminMaxPrice.Value);
                }
                if (!string.IsNullOrEmpty(parameters.AdminMinYear))
                {
                    query += "AND Year >= @AdminMinYear ";
                    cmd.Parameters.AddWithValue("@AdminMinYear", parameters.AdminMinYear);
                }
                if (!string.IsNullOrEmpty(parameters.AdminMaxYear))
                {
                    query += "AND Year <= @AdminMaxYear ";
                    cmd.Parameters.AddWithValue("@AdminMaxYear", parameters.AdminMaxYear);
                }
                if (!string.IsNullOrEmpty(parameters.AdminMakeName))
                {
                    query += "AND MakeName = @AdminMakeName ";
                    cmd.Parameters.AddWithValue("@AdminMakeName", parameters.AdminMakeName);
                }
                if (!string.IsNullOrEmpty(parameters.AdminModelName))
                {
                    query += "AND ModelName = @AdminModelName ";
                    cmd.Parameters.AddWithValue("@AdminModelName", parameters.AdminModelName);
                }
                if (!string.IsNullOrEmpty(parameters.AdminYear))
                {
                    query += "AND Year = @AdminYear ";
                    cmd.Parameters.AddWithValue("@AdminYear", parameters.AdminYear);
                }
                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleShortItem row = new VehicleShortItem();

                        row.VehicleId = (int)dr["VehicleId"];
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.Year = dr["Year"].ToString();
                        row.Transmission = dr["Transmission"].ToString();
                        row.Color = dr["Color"].ToString();
                        row.Interior = dr["Interior"].ToString();
                        row.Type = dr["Type"].ToString();
                        row.Vin = dr["Vin"].ToString();
                        row.Price = (decimal)dr["Price"];
                        row.Msrp = (decimal)dr["Msrp"];
                        row.IsSold = (bool)dr["IsSold"];
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelName = dr["ModelName"].ToString();
                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();
                        vehicles.Add(row);
                    }
                }
            }
            return vehicles;
        }

        public void Purchased(Purchase purchase)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchasedVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("PurchaseId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Name", purchase.Name);
                cmd.Parameters.AddWithValue("@Email", purchase.Email);
                cmd.Parameters.AddWithValue("@StreetOne", purchase.StreetOne);
                cmd.Parameters.AddWithValue("@StreetTwo", purchase.StreetTwo);
                cmd.Parameters.AddWithValue("@City", purchase.City);
                cmd.Parameters.AddWithValue("@Zipcode", purchase.Zipcode);
                cmd.Parameters.AddWithValue("@Phone", purchase.Phone);
                cmd.Parameters.AddWithValue("@PaymentOption", purchase.PaymentOption);
                cmd.Parameters.AddWithValue("@PurchasePrice", purchase.PurchasePrice);
                cmd.Parameters.AddWithValue("@StateId", purchase.StateId);
                cmd.Parameters.AddWithValue("@VehicleId", purchase.VehicleId);
                cn.Open();
                cmd.ExecuteNonQuery();
                purchase.PurchaseId = (int)param.Value;
            }
        }

        public IEnumerable<InventoryReport> Reports(string vehicleType)
        {
            List<InventoryReport> vehicles = new List<InventoryReport>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetVehiclesReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@prm_vehicleType", SqlDbType.NVarChar).Value = vehicleType;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReport row = new InventoryReport();
                        row.Year = dr["Year"].ToString();
                        row.MakeName = dr["MakeName"].ToString();
                        row.StockValue = (decimal)dr["StockValue"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.Count = (int)dr["Count"];
                        vehicles.Add(row);
                    }
                }
            }
            return vehicles;
        }
    }
}
