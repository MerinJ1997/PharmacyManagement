using PharmacyManagement.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PharmacyManagement.ViewModel
{
   public class MainModelView:BaseViewModel
    {
        private BaseViewModel _selectedview = new HomeViewModel();

        public BaseViewModel SelectedView
        {
            get { return _selectedview; }
            set { _selectedview = value; OnPropertyChanged(nameof(SelectedView)); }
        }
        public ICommand AddUserCommand { get; set; }

        public MainModelView()
        {
            AddUserCommand = new AddUserCommand(this);
        }


    }
}
