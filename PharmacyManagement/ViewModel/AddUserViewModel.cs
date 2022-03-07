using EntityLayer;
using PharmacyManagement.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PharmacyManagement.ViewModel
{
    public class AddUserViewModel : BaseViewModel /*INotifyDataErrorInfo*/

    {
        //public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private AddUserDetailsModel addUserDetailsModel;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged("Address"); }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set 
            {
               
                _email = value; OnPropertyChanged("Email"); 
            }
        }
        private string _phoneNo;

        public string PhoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; OnPropertyChanged("PhoneNo"); }
        }
        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged("Age"); }
        }
        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; OnPropertyChanged("Gender"); }
        }
        private string _role;

        public string Role
        {
            get { return _role; }
            set { _role = value; OnPropertyChanged("Role"); }
        }
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }
        public ICommand Submit { get; set; }

        //public bool HasErrors => throw new NotImplementedException();

        public AddUserViewModel(AddUserDetailsModel model)
        {
            this.addUserDetailsModel = model;
            Submit = new AddUserSubmitCommand(this);
        }

        //public IEnumerable GetErrors(string propertyName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
