using BusinessLayer;
using EntityLayer;
using PharmacyManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PharmacyManagement.Commands
{
    public class BillingCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public BillingViewModel billingView { get; set; }
        public BillingCommand(BillingViewModel billing)
        {
            billingView = billing;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        
        public void Execute(object parameter)
        {
            //StockModel stocks = new StockModel();
            //stocks.MedID = billingView.Medid;
            //stocks.MedName = billingView.Name;
            //stocks.UnitPrice = billingView.Price;
            ////stocks.StockAvailable = billingView.StockAvailable;
            //BillBussiness bb = new BillBussiness();
            //bb.fetchMedicine(stocks);
            //string medid = billingView.Medid.ToString();
            //Int64 Qty = billingView.Quantity;
            //if(Qty <= stocks.StockAvailable)
            //{
            //    stock= stocks.StockAvailable;
            //    newStock = stock - Qty;
            //    stock = newStock;
            //}
            //else
            //{
            //    MessageBox.Show("Exceeded stock limit. Please enter value less than" + stock);
            //}
        }
    }
}
