﻿using CarDealership.Data.ADO;
using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Factory
{
    public class VehicleRepositoryFactory
    {
        public static IVehicleRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new VehicleRepositoryADO();
                default:
                    throw new Exception("Could not find valid RepositoryType");
            }
            
        }
    }
}
