
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
    public class BillingViewModel : BaseViewModel
    {
        public StockModel stock { get; set; }
        private int _medid;

        public int Medid
        {
            get { return _medid; }
            set { _medid = value;OnPropertyChanged("Medid"); }
        }
        private float _price;

        public float Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged("Price"); }
        }
        private int _stockAvailable;

        public int StockAvailable
        {
            get { return _stockAvailable; }
            set { _stockAvailable = value; OnPropertyChanged("StockAvailable"); }
        }
        private Int64 _quantity;

        public Int64 Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged("Quantity"); }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public ICommand BillCommand { get; set; }
        public BillingViewModel(StockModel stockModel)
        {
            this.stock = stockModel;
            BillCommand = new BillingCommand(this);
        }


    }
    
}
