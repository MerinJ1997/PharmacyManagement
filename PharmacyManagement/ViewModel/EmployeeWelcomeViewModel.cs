using PharmacyManagement.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PharmacyManagement.ViewModel
{
    public class EmployeeWelcomeViewModel : BaseViewModel
    {
        private BaseViewModel _selectedview = new EmployeeDetailViewModel();

        public BaseViewModel SelectedView
        {
            get { return _selectedview; }
            set { _selectedview = value; OnPropertyChanged(nameof(SelectedView)); }
        }
        public ICommand EmployeeCommand { get; set; }
        public EmployeeWelcomeViewModel()
        {
            EmployeeCommand = new EmployeeCommand(this);
        }

       
    }
}
