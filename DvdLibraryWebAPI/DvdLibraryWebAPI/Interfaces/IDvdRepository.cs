using DvdLibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibraryWebAPI.Interfaces
{
    public interface IDvdRepository
    {
        List<Dvd> GetAll();
        Dvd Get(int id);
        void Add(Dvd dvd);
        void Edit(Dvd dvd);
        void Delete(int ID);
    }
}