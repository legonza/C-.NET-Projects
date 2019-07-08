using SWCCorp.Models;
using SWCCorp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Data
{
    public class TaxRepository : IOrderTaxRepository
    {
        List<Tax> taxes = new List<Tax>();
        public static Tax MapToTax(string row)
        {
            string[] values = row.Split('~');
            Tax t = new Tax();
            t.StateAbbreviation = values[0];
            t.StateName = values[1];
            decimal.TryParse(values[2], out decimal value);
            t.TaxRate = value;
            return t;
        }
        public List<Tax> GetTaxInfo()
        {
            using (StreamReader sr = new StreamReader("C:\\Users\\gonza\\source\\repos\\SWCCorp\\SWCCorp\\bin\\Debug\\taxes.txt"))
            {
                string line = string.Empty;
                while((line = sr.ReadLine()) != null)
                {
                    Tax t = MapToTax(line);
                    taxes.Add(t);
                }

            }
            return taxes;
        }
    }
}
