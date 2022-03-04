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
    public class AddUserSubmitCommand : ICommand
    {
        public AddUserViewModel ViewModel { get; set; }
        public AddUserSubmitCommand(AddUserViewModel addUserViewModel)
        {
            this.ViewModel = addUserViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AddUserDetailsModel add = new AddUserDetailsModel();
            AddUserBusiness addUserBusiness = new AddUserBusiness();    
            add.Name = ViewModel.Name;
            add.Address = ViewModel.Address;
            add.Email = ViewModel.Email;
            add.Phone = ViewModel.PhoneNo;
            add.Gender = ViewModel.Gender;
            add.Age = ViewModel.Age;
            add.Role = ViewModel.Role;
            add.username = ViewModel.Username;
            add.password = ViewModel.Password;
            addUserBusiness.SaveUser(add);
        }
    }
}
