using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class StockModel
    {
        public int MedID { get; set; }
        public string MedName { get; set; }
        public string Company { get; set; }
        public int StockAvailable { get; set; }
        public double UnitPrice { get; set; }
        public DateTime Expiry { get; set; }
    }
}
