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
    }

}
