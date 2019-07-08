namespace DvdLibraryWebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DvdLibraryWebAPI.Models.DvdListEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DvdLibraryWebAPI.Models.DvdListEntities context)
        {
            context.Dvds.AddOrUpdate(
                d=>d.dvdId,
                new Models.Dvd { dvdId = 1, title = "The Burning Tower", releasedYear = 2003, director = "Robert Johnson", rating = "R", notes = "all will vanish"},
                new Models.Dvd { dvdId = 2, title = "Go Now", releasedYear = 2005, director = "Emily Carlson", rating = "PG", notes = "run" },
                new Models.Dvd { dvdId = 3, title = "The Dark Zone", releasedYear = 2008, director = "John Axberg", rating = "R", notes = "zone zone" }
            );
            context.SaveChanges();

        }
    }
}
