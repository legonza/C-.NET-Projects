using DvdLibraryWebAPI.Controllers;
using DvdLibraryWebAPI.Interfaces;
using DvdLibraryWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DvdLibraryWebAPI
{
    public class RepositoryFactory
    {
        public static IDvdRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "Test":
                    return new MockRepository();
                case "ADOProgram":
                    return new ADORepository();
                case "EntityProgram":
                    return new EntityRepository();
                default:
                    throw new Exception("Mode value in app config not valid");

            }
        }
    }
}