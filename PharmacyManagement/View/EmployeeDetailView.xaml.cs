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
    /// Interaction logic for EmployeeDetailView.xaml
    /// </summary>
    public partial class EmployeeDetailView : UserControl
    {
        public EmployeeDetailView()
        {
            InitializeComponent();
        }
        public void UserControl1_Load(Object sender, EventArgs e)
        {

            SqlConnection connection = null;
            using (connection = new SqlConnection("data source =.; database = PharmacyManagement; integrated security = SSPI"))
            {

                var query = "Select * from UserDetails where EmployeeID =5 and RoleID =1";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                // SqlDataReader sqlDataReader = command.ExecuteReader();


                using (SqlDataReader sdr = command.ExecuteReader())
                {
                    sdr.Read();
                    name.Text = sdr["EmployeeName"].ToString();
                    Address.Text = sdr["EmployeeAddress"].ToString();
                    phno.Text = sdr["PhoneNo"].ToString();
                    Email.Text= sdr["Email"].ToString();


                }
                connection.Close();

            }


        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            SqlConnection connection = null;
            using (connection = new SqlConnection("data source =.; database = PharmacyManagement; integrated security = SSPI"))
            {

                int empid = 5;
                string Name = name.Text;
                string ph = phno.Text;
                string mail = Email.Text;
                string add = Address.Text;
                string query = "update UserDetails set EmployeeAddress= @add , PhoneNo= @ph  ,Email=@email, EmployeeName = @ename where EmployeeID=@empid";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@empid", empid);
                command.Parameters.AddWithValue("@add", add);
                command.Parameters.AddWithValue("@ph", ph);
                command.Parameters.AddWithValue("@email", mail);
                command.Parameters.AddWithValue("@ename", Name);




                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");
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
