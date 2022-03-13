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
        public float UnitPrice { get; set; }
        public DateTime Expiry { get; set; }
        public int Quantity{ get; set; }
        public string Total { get; set; }
        public float TotalAmount { get; set; }
        public double GST { get; set; }
        public int InvoiceNo { get; set; }
        public string Date { get; set; }
    }
}
