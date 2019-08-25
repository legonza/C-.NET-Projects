﻿using CarDealership.Data.ADO;
using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Factory
{
    public class StateRepositoryFactory
    {
        public static IStateRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new StateRepositoryADO();
                default:
                    throw new Exception("Could not find valid RepositoryType");
            }
        }
    }
}
