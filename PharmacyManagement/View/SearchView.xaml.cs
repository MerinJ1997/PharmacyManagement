using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        SqlConnection  con= null;
        SqlDataAdapter adap = null;
        public SearchView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                MessageBox.Show("Searching for result");
                con = new SqlConnection("data source =.; database = PharmacyManagement; integrated security = SSPI");
                con.Open();
                string search = TextBox1.Text;
                string cmdst = "select MedicineName,Price,StockAvailable from StockDetails where MedicineName like '"+search+"%'";
                
                adap = new SqlDataAdapter(cmdst, con);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                con.Close();
                GridView.ItemsSource = (System.Collections.IEnumerable)ds;
                //for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                //{
                //    string first = ds.Tables[0].Rows[i]["MedicineName"].ToString();
                //    string second=ds.Tables[1].Rows[i]["Price"].ToString();
                //    string Third = ds.Tables[2].Rows[i]["StockAvailable"].ToString();


                //}
                
                //GridView1.da= ds.Tables[0];
                //GridView1.DataBind();
            }
            catch (Exception pp)
            {
                Console.WriteLine("No data found");
            }
        } 
    }
}
