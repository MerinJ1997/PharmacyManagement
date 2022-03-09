
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




    }
    
}
