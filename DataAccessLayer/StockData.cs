using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataAccessLayer
{
    public class StockData
    {
        public List<StockModel> GetStock()
        {
            try
            {
                List<StockModel> stock = new List<StockModel>();
                PharmacyManagementEntities pharmacy = new PharmacyManagementEntities();
                var data = from ph in pharmacy.StockDetails
                           select ph;
                foreach (var item in data)
                {
                    StockModel stockModel = new StockModel();
                    stockModel.MedID = item.MedID;
                    stockModel.MedName = item.MedicineName;
                    stockModel.Company = item.CompanyName;
                    stockModel.StockAvailable = item.StockAvailable;
                    stockModel.UnitPrice = (float)item.Price;
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

        public void SaveStockData(StockModel stockModel)
        {
            PharmacyManagementEntities pharmacy = new PharmacyManagementEntities();
            StockDetail stocks = new StockDetail();
            stocks.MedicineName = stockModel.MedName;
            stocks.MedID = stockModel.MedID;
            stocks.CompanyName = stockModel.Company;
            stocks.Price = stockModel.UnitPrice;
            stocks.StockAvailable = stockModel.StockAvailable;
            stocks.ExpiryDate = stockModel.Expiry;
            pharmacy.StockDetails.Add(stocks);
            pharmacy.SaveChanges();
            MessageBox.Show("Saved Succesfully");

        }
        public void DeleteStockData(StockModel StockModel)
        {
            try
            {
                PharmacyManagementEntities entities = new PharmacyManagementEntities();
                var result = from Obj in entities.StockDetails
                             where Obj.MedID == StockModel.MedID
                             select Obj;
                foreach (var entity in result)
                {
                    entities.StockDetails.Remove(entity);
                }
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
