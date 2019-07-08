using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DvdLibraryWebAPI.Models
{
    public class DvdListEntities : DbContext
    {
        public DvdListEntities() : base("DvdLibraryDatabase")
        {

        }
        public DbSet<Dvd> Dvds { get; set; }
    }
}