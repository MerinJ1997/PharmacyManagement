using BusinessLayer;
using EntityLayer;
using PharmacyManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            StockModel sm = new StockModel();
            UpdateStockBusiness updateStockBusiness = new UpdateStockBusiness();
            sm.MedID = addStockViewModel.MedId;
            sm.MedName = addStockViewModel.MedName;
            sm.Company=addStockViewModel.Company;
            sm.UnitPrice = addStockViewModel.Price;
            sm.StockAvailable = addStockViewModel.Stocks;
            sm.Expiry = addStockViewModel.Expiry;
            updateStockBusiness.SaveStockBussiness(sm);
    
        }
    }
}
