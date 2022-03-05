using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UpdateStockBusiness
    {
        public List<StockModel> GetStockToDisplay()
        {
            StockData model = new StockData();
            return model.GetStock();
        }
        public void SaveStockBussiness(StockModel stockModel)
        {
            StockData stockData = new StockData();
            stockData.SaveStockData(stockModel);
        }
        public void DeleteData(StockModel stockModel)
        {
            StockData stockData = new StockData();
            stockData.DeleteStockData(stockModel);

        }
    }
}
