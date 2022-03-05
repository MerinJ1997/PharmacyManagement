using PharmacyManagement.View;
using PharmacyManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PharmacyManagement.Commands
{
    public class EmployeeCommand : ICommand

    {
        public EmployeeWelcomeViewModel model;

        public EmployeeCommand(EmployeeWelcomeViewModel employeeWelcomeViewModel)
        {
          this.model = employeeWelcomeViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "My Profile")

            {
                model.SelectedView = new EmployeeDetailViewModel();
            }
            else if (parameter.ToString() == "Billing")

            {
                model.SelectedView = new BillingViewModel();
            }
            
            else if (parameter.ToString() == "Log Out")

            {
                model.SelectedView = new LoginViewModel();
            }
        }
    }
}
