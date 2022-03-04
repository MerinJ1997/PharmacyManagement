using PharmacyManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PharmacyManagement.Commands
{
    public class AddUserCommand : ICommand
    {
        public MainModelView model;
        public AddUserCommand(MainModelView viewModel)
        {
            this.model = viewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "addUser")

            {
                model.SelectedView = new AddUserViewModel(new EntityLayer.AddUserDetailsModel());
            }
            else if (parameter.ToString() == "ViewUpdateUser")

            {
                model.SelectedView = new ViewUpdateUserViewModel();
            }
            else if (parameter.ToString() == "ViewStock")
            {
                model.SelectedView = new StockViewModel();
            }
            else if (parameter.ToString() == "AddStock")
            {
                model.SelectedView = new AddStockViewModel();
            }
            else if (parameter.ToString() == "Logout")
            {
                model.SelectedView = new LoginViewModel();
            }



        }
    }
}
