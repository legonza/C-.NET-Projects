using DvdLibraryWebAPI.Interfaces;
using DvdLibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibraryWebAPI.Repositories
{
    public class MockRepository : IDvdRepository
    {
        
        private static List<Dvd> _dvd = new List<Dvd>
        {
        new Dvd
        { dvdId=1, title="Scream", releasedYear=2010, director="Larry Jones", rating="PG", notes="Very scary"  },
        new Dvd
        { dvdId=2, title="Hunt", releasedYear=2002, director="Bob Johnson", rating="R", notes="Run"  },
        new Dvd
        { dvdId=3, title="Altoids", releasedYear=2000, director="Sarah Kelly", rating="PG-13", notes="Yummm"  }
        };

        public List<Dvd> GetAll()
        {
            return _dvd;
        }

        public Dvd Get(int Id)
        {
            return _dvd.FirstOrDefault(m => m.dvdId == Id);
        }

        public void Add(Dvd dvd)
        {
            dvd.dvdId = _dvd.Max(m => m.dvdId) + 1;
            _dvd.Add(dvd);
        }

        public void Edit(Dvd dvd)
        {
            var found = _dvd.FirstOrDefault(m => m.dvdId == dvd.dvdId);

            if (found != null)
                found = dvd;
            _dvd.RemoveAll(d => d.dvdId == dvd.dvdId);
            _dvd.Add(dvd);
        }

        public void Delete(int ID)
        {
            _dvd.RemoveAll(m => m.dvdId == ID);
        }
        
    }
}