﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibraryWebAPI.Models
{
    public class Dvd
    {
        public int dvdId { get; set; }
        public string title { get; set; }
        public int releasedYear { get; set; }
        public string director { get; set; }
        public string rating { get; set; }
        public string notes { get; set; }
    }
}