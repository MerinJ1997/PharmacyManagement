using BusinessLayer;
using EntityLayer;
using PharmacyManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PharmacyManagement.Commands
{
    public class StockSubmitCommand : ICommand

    {
        public AddStockViewModel addStockViewModel;
        public StockSubmitCommand(AddStockViewModel ViewModel)
        {
            addStockViewModel = ViewModel;
        }
        Regex rName = new Regex(@"^[a-zA-Z]+$");
        Regex rUnit = new Regex(@"^[0-9]+$");

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string Name = addStockViewModel.MedName;
            string Company = addStockViewModel.Company;
            string UnitPrice = addStockViewModel.Price.ToString();
            string StockAvailable = addStockViewModel.Stocks.ToString();
            string Expiry = addStockViewModel.Expiry.ToString();
            StockModel sm = new StockModel();
            UpdateStockBusiness updateStockBusiness = new UpdateStockBusiness();

            if (Name != null && Company != null && UnitPrice != null && StockAvailable != null && Expiry != null)
            {
                if(Name.Length > 0)
                {
                    if (!rName.IsMatch(Name))
                    {
                        MessageBox.Show("Invalid Medicine Name");
                    }
                    if (!rName.IsMatch(Company))
                    {
                        MessageBox.Show("Invalid Medicine Name");
                    }
                    else if (!rUnit.IsMatch(UnitPrice))
                    {
                        MessageBox.Show("Invalid Price");
                    }
                    else if (!rUnit.IsMatch(StockAvailable))
                    {
                        MessageBox.Show("Invalid Price");
                    }
                    else
                    {                        
                        sm.MedID = addStockViewModel.MedId;
                        sm.MedName = addStockViewModel.MedName;
                        sm.Company = addStockViewModel.Company;
                        sm.UnitPrice = addStockViewModel.Price;
                        sm.StockAvailable = addStockViewModel.Stocks;
                        sm.Expiry = addStockViewModel.Expiry;
                        updateStockBusiness.SaveStockBussiness(sm);
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter Values");
            }
            
    
        }
    }
}
