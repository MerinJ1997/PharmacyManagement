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
    public class AddStockViewModel : BaseViewModel
    {

        private StockModel _model;

        public ICommand StockSubmitCommand { set; get; }
        public AddStockViewModel(StockModel viewmodel)
        {
            _model = viewmodel;
            StockSubmitCommand = new StockSubmitCommand(this);
        }
        
        private int _medID;

        public int MedId
        {
            get { return _medID; }
            set { _medID = value; OnPropertyChanged("MedId"); }
        }

        private string _medName;

        public string MedName
        {
            get { return _medName; }
            set { _medName = value; OnPropertyChanged("MedName"); }
        }

        private string _company;
        public string Company
        {
            get { return _company; }
            set { _company = value; OnPropertyChanged("Company"); }
        }

        private int  _stock;

        public int  Stocks
        {
            get { return _stock; }
            set { _stock = value; OnPropertyChanged("Stocks"); }
        }

        private float _price;

        public float Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged("Price"); }
        }

        private DateTime _expire=DateTime.Now;

        public DateTime Expiry
        {
            get { return _expire; }
            set { _expire = value; OnPropertyChanged("Expiry"); }
        }





    }
}
