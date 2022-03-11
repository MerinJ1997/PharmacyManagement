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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PharmacyManagement.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=.;Database=PharmacyManagement;Integrated Security=SSPI");
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();
                string query = "select RoleID from Users where Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                int RoleID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (RoleID == 1)
                {
                    EmployeeWelcomeView dashboard = new EmployeeWelcomeView();
                    dashboard.Show();
                    MessageBox.Show("Employee Login Successfully Completed");
                   // this.Close();
                }
                else if(RoleID == 2)
                {
                    AdminPageView dashboard = new AdminPageView();
                    dashboard.Show();
                    MessageBox.Show("Admin Login Successfully Completed");

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
                sqlCon.Close();
            }
        }
    }
}
