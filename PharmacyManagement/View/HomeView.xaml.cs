using System;
using System.Collections.Generic;
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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }
        public void UserControl1_Load(Object sender, EventArgs e)
        {

            SqlConnection connection = null;
            using (connection = new SqlConnection("data source =.; database = PharmacyManagement; integrated security = SSPI"))
            {

                var query = "Select * from UserDetails where EmployeeID =7 and RoleID =2";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                // SqlDataReader sqlDataReader = command.ExecuteReader();


                using (SqlDataReader sdr = command.ExecuteReader())
                {
                    sdr.Read();
                    txtph.Text = sdr["PhoneNo"].ToString();
                    txtadd.Text = sdr["EmployeeAddress"].ToString();
                    txtmail.Text = sdr["Email"].ToString();


                }
                connection.Close();

            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            using (connection = new SqlConnection("data source =.; database = PharmacyManagement; integrated security = SSPI"))
            {

                int empid = 7;
                string ph = txtph.Text;
                string mail = txtmail.Text;
                string add = txtadd.Text;
                string query = "update UserDetails set EmployeeAddress= @add , PhoneNo= @ph  ,Email=@email where EmployeeID=@empid";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@empid", empid);
                command.Parameters.AddWithValue("@add", add);
                command.Parameters.AddWithValue("@ph", ph);
                command.Parameters.AddWithValue("@email", mail);


                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Updated..");
                }
                catch (Exception)
                {
                    MessageBox.Show(" Not Updated");
                }
                finally
                {
                    connection.Close();
                }
            }

        }
    }
}
