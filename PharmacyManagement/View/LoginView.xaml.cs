using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PharmacyManagement.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }
        private void Button_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginModel lm = new LoginModel();
                LoginBussiness LB = new LoginBussiness();
                lm.username = txtUsername.Text;
                lm.password = txtPassword.Password;
                LB.logindetails(lm);
                int id = lm.roleid;

                if (id == 1)
                {

                    string name = lm.name;
                    string address = lm.address;
                    string phone = lm.phone;
                    string email = lm.email;
                    EmployeeWelcomeView dashboard = new EmployeeWelcomeView();
                    dashboard.name.Text = name;
                    dashboard.address.Text = address;
                    dashboard.phone.Text = phone;
                    dashboard.email.Text = email;
                    dashboard.Show();
                    MessageBox.Show("Employee Login Successfully Completed");
                    this.Close();
                }

                else if (id == 2)
                {

                    string name = lm.name;
                    string address = lm.address;
                    string phone = lm.phone;
                    string email = lm.email;
                    AdminPageView dashboard = new AdminPageView();
                    dashboard.name.Text = name;
                    dashboard.phone.Text = phone;
                    dashboard.email.Text = email;

                    dashboard.Show();
                    MessageBox.Show("Admin Login Successfully Completed");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Invalid Username or Password...Please Try Again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

           

        private void BackButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
