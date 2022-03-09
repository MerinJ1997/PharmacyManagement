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
    public class SearchStockCommand : ICommand
    {
        public SearchViewModel SearchStock;
        public SearchStockCommand(SearchViewModel stockviewModel)
        {
            this.SearchStock = stockviewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            StockModel stockModel = new StockModel();
            stockModel.MedName = SearchStock.MedName;
            UpdateStockBusiness sb = new UpdateStockBusiness();
            sb.Search(stockModel);
        }
    }
}
