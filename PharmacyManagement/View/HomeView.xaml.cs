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


        //    SqlConnection connection = null;
        //    using (connection = new SqlConnection("data source =.; database = PharmacyManagement; integrated security = SSPI"))
        //    {

        //        var query = "Select * from UserDetails where EmployeeID =4 and RoleID =2";

        //        SqlCommand command = new SqlCommand(query, connection);
        //        connection.Open();
        //        // SqlDataReader sqlDataReader = command.ExecuteReader();


        //        using (SqlDataReader sdr = command.ExecuteReader())
        //        {
        //            sdr.Read();
        //            txtph.Text = sdr["PhoneNo"].ToString();
        //            txtadd.Text = sdr["EmployeeAddress"].ToString();
        //            txtmail.Text = sdr["Email"].ToString();


        //        }
        //        connection.Close();

        //    }
        //}

       
    }
}
