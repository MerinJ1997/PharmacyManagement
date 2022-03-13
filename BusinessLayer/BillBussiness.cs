using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BillBussiness
    {

        public List<StockModel> SearchData(StockModel add)
        {
            BillData bd = new BillData();
            return bd.SearchData(add);
        }

        public List<StockModel> fetchMedicine(StockModel add)
        {
            BillData bd = new BillData();
            return bd.FetchDataByMedName(add);
        }
        public void UpdateQuantity(StockModel add)
        {
            BillData bd =new BillData();
            bd.Update(add);
        }
        public void GetBill(StockModel add)
        {
            BillData billData = new BillData();
            billData.SaveBillData(add);
        }
        public void Bill(StockModel add)
        {
            BillData billData = new BillData();
            billData.SaveBillData(add);
        }
        public void Bill2(StockModel add)
        {
            BillData billData = new BillData();
            billData.SaveBillData2(add);
        }
        public List<StockModel> GetBillDet()
        {
            BillData billData = new BillData();
            return billData.GetBillData();
        }
    }

}
