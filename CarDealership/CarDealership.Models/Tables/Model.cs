using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Model
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public DateTime AddedDate { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string MakeName { get; set; }
    }
}
