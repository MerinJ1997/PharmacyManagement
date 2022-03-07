using PharmacyManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PharmacyManagement.Commands
{
    public class HomePageCommands : ICommand
    {
        public MainPageViewModel model;
        public HomePageCommands(MainPageViewModel mviewModel)
        {
            this.model = mviewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
             if (parameter.ToString() == "Aboutus")
            {
                model.SelectedView = new AboutUsViewModel();
            }
            else if (parameter.ToString() == "Home")
            {
                model.SelectedView = new MainPageHomeViewModel();
            }
            else if (parameter.ToString() == "Contactus")
            {
                model.SelectedView = new ContactUsViewModel();
            }
            else if (parameter.ToString() == "Login")
            {
                model.SelectedView = new LoginViewModel();
            }
             else if (parameter.ToString() =="Search")
            {
                model.SelectedView = new SearchViewModel(); 
            }
        }
    }
}
