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
    //public class Validation
    //{
    //    public static string Validate_Phone = "^[6-9]{1}[0-9]{9}$";
    //    public static string Validate_Email = "^[0-9a-zA-Z]([._+-]{0,})+[@][a-zA-Z]{2,3}([.][a-zA-Z]{2,3}){0,1}&";
    //    public static string Validate_Password = "^[a-zA-Z0-9]{8,}$"/*+[@#$%&*]{0,1}*/;
    //}
    public class AddUserSubmitCommand : ICommand
    {
        public AddUserViewModel ViewModel { get; set; }
        public AddUserSubmitCommand(AddUserViewModel addUserViewModel)
        {
            this.ViewModel = addUserViewModel;
        }
        Regex rEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex rPhone = new Regex(@"^[6-9][0-9]{9}");
        Regex rPassword = new Regex(@"^([\w\.\*\@]){8,}");

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AddUserDetailsModel add = new AddUserDetailsModel();
            AddUserBusiness addUserBusiness = new AddUserBusiness();
            
            string Name = ViewModel.Name;
            string Address = ViewModel.Address;
            string Email = ViewModel.Email;
            string Phone = Convert.ToString(ViewModel.PhoneNo);
            string Gender = ViewModel.Gender;
            string Age = ViewModel.Age.ToString();
            string Role = ViewModel.Role;
            string Username = ViewModel.Username;
            string Password = ViewModel.Password;
            if (Name != null && Address != null && Email != null && Phone != null && Gender != null && Age!= null && Role != null && Username != null && Password != null)
            {
                if (Email.Length > 0)
                {
                    if (!rEmail.IsMatch(Email))
                    {
                        MessageBox.Show("Invalid Email", "Error", MessageBoxButton.OK);
                    }
                    else if (!rPhone.IsMatch(Phone))
                    {
                       MessageBox.Show("Invalid Phone number", "Error", MessageBoxButton.OK);
                    }
                    else if (!rPassword.IsMatch(Password))
                    {
                        MessageBox.Show("Invalid Password", "Error", MessageBoxButton.OK);
                    }
                    else
                    {
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
            else
            {
                MessageBox.Show("Enter Values");
            }
        }
    }
}
