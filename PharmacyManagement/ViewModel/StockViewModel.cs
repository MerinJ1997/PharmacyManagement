using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.ViewModel
{
    public class StockViewModel: BaseViewModel
    {
        public List<StockModel> list { get; set; }
        public StockViewModel()
        {
            list = new List<StockModel>();
            UpdateStockBusiness stock = new UpdateStockBusiness();
            list = stock.GetStockToDisplay();
        }

    }
}
