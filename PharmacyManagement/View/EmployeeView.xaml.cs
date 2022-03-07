using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PharmacyManagement.View
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    
    public partial class EmployeeView : UserControl
    {
        public int id { get; set; }
        public EmployeeView()
        {
            InitializeComponent();
            Refresh();
        }
        Regex ValidateEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex ValidatePhone = new Regex(@"^[6-9][0-9]{9}");
        Regex ValidatePassword = new Regex(@"^([\w\.\*\@]){8,}");

        private void DeleteUserData(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.Items.Count > 0)
                {
                    var value = (DataGrid.SelectedItem as AddUserDetailsModel).ID;
                    AddUserDetailsModel Model = new AddUserDetailsModel();
                    AddUserBusiness add = new AddUserBusiness();
                    Model.ID = value;
                    add.DeleteData(Model);
                    MessageBox.Show("User Data Deleted :" + Model.ID);
                    Refresh();
                }
                else
                {
                    MessageBox.Show("No User available for Delete:??");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void Refresh()
        {
            AddUserBusiness add = new AddUserBusiness();
            DataGrid.ItemsSource = add.GetUserDetails();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddUserDetailsModel Model = new AddUserDetailsModel();
            
            string Email = Model.Email;
            string Phone = Convert.ToString(Model.Phone);
            string Password = Model.password;
            if (txtemail.Text.Length > 0)
            {
                if (!ValidateEmail.IsMatch(txtemail.Text))
                {
                    MessageBox.Show("Invalid Email", "Error", MessageBoxButton.OK);
                }
                else if (!ValidatePhone.IsMatch(txtphone.Text))
                {
                    MessageBox.Show("Invalid Phone Number", "Error", MessageBoxButton.OK);
                }
                else
                {
                    Model.ID = id;
                    Model.Name = txtname.Text;
                    Model.Address = txtaddress.Text;
                    Model.Phone = txtphone.Text;
                    Model.Email = txtemail.Text;
                    Model.Gender = cmbgender.Text;
                    Model.Age = Convert.ToInt32(txtage.Text);
                    Model.Role = txtrole.Text;
                    AddUserBusiness addUserBusiness = new AddUserBusiness();
                    addUserBusiness.UpdateData(Model);
                    MessageBox.Show("User Details Edited");
                }
            }
            Refresh();
            ClearTextBox();
        }
        private void EditUserData(object sender, RoutedEventArgs e)
        {
            id = (DataGrid.SelectedItem as AddUserDetailsModel).ID;
            txtname.Text = (DataGrid.SelectedItem as AddUserDetailsModel).Name;
            txtaddress.Text = (DataGrid.SelectedItem as AddUserDetailsModel).Address;
            txtphone.Text = (DataGrid.SelectedItem as AddUserDetailsModel).Phone;
            txtemail.Text = (DataGrid.SelectedItem as AddUserDetailsModel).Email;
            cmbgender.Text = (DataGrid.SelectedItem as AddUserDetailsModel).Gender;
            txtage.Text = (DataGrid.SelectedItem as AddUserDetailsModel).Age.ToString();
            txtrole.Text = (DataGrid.SelectedItem as AddUserDetailsModel).Roling.RoleName;
        }
        void ClearTextBox()
        {
            //txtId.Text = String.Empty;
            txtname.Text = String.Empty;
            txtaddress.Text = String.Empty;
            txtphone.Text = String.Empty;
            txtemail.Text = String.Empty;
            cmbgender.Text = String.Empty;
            txtage.Text = String.Empty;
            txtrole.Text = String.Empty;

        }
    }
}
