using DvdLibraryWebAPI.Interfaces;
using DvdLibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DvdLibraryWebAPI.Repositories
{
    public class EntityRepository : IDvdRepository
    {
        public List<Dvd> GetAll()
        {
            var repository = new DvdListEntities();

            var model = (from c in repository.Dvds
                         select c).ToList();
            return model;
        }

        public Dvd Get(int id)
        {
            var repository = new DvdListEntities();
            Dvd dvd = new Dvd();
            dvd = repository.Dvds.FirstOrDefault(c => c.dvdId.Equals(id));
            return dvd;
        }

        public void Add(Dvd dvd)
        {
            var repository = new DvdListEntities();

            repository.Dvds.Add(dvd);
            repository.SaveChanges();
        }

        public void Edit(Dvd dvd)
        {
            var repository = new DvdListEntities();
            Dvd model = repository.Dvds.FirstOrDefault(d => d.dvdId.Equals(dvd.dvdId));
            model.title = dvd.title;
            model.releasedYear = dvd.releasedYear;
            model.director = dvd.director;
            model.rating = dvd.rating;
            model.notes = dvd.notes;
            repository.SaveChanges();
        }

        public void Delete(int ID)
        {
            var repository = new DvdListEntities();
            Dvd model = repository.Dvds.FirstOrDefault(c => c.dvdId.Equals(ID));
            if (repository.Dvds.Any(c => c.dvdId == ID))
            {
                repository.Dvds.Remove(model);
                repository.SaveChanges();
            }
        }

    }
}