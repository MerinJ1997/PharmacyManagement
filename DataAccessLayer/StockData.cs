using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StockData
    {
        public List<StockModel> GetStock()
        {
            try
            {
                List<StockModel> stock = new List<StockModel>();
                PharmacyManagementEntities1 pharmacy = new PharmacyManagementEntities1();
                var data = from ph in pharmacy.StockDetails
                           select ph;
                foreach (var item in data)
                {
                    StockModel stockModel = new StockModel();
                    stockModel.MedID = item.MedID;
                    stockModel.MedName = item.MedicineName;
                    stockModel.Company = item.CompanyName;
                    stockModel.StockAvailable = item.StockAvailable;
                    stockModel.UnitPrice = item.Price;
                    stockModel.Expiry = item.ExpiryDate;
                    stock.Add(stockModel);
                }
                return stock;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
