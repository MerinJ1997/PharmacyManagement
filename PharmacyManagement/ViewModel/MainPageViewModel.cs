using PharmacyManagement.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PharmacyManagement.ViewModel
{
    public class MainPageViewModel:BaseViewModel
    {
        private BaseViewModel _selectedview = new MainPageHomeViewModel();

        public BaseViewModel SelectedView
        {
            get { return _selectedview; }
            set { _selectedview = value; OnPropertyChanged(nameof(SelectedView)); }
        }
        public ICommand HomePageCommands { get; set; }

        public MainPageViewModel()
        {
            HomePageCommands = new HomePageCommands(this);
        }
    }
}
