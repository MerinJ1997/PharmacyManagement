using BusinessLayer;
using EntityLayer;
using PharmacyManagement.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PharmacyManagement.ViewModel
{
    public class SearchViewModel : BaseViewModel
    {
        private StockModel _stockModel;
        private string _medName;
        public string MedName
        {
            get { return _medName; }
            set { _medName = value; }
        }
        public ICommand Submit { get; set; }
        public SearchViewModel(StockModel model)
        {
            this._stockModel = model;
            Submit = new SearchStockCommand(this);
        }
        
    }
}
