using BusinessLayer;
using EntityLayer;
using System;
using System.Collections;
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
    /// Interaction logic for BillingView.xaml
    /// </summary>
    public partial class BillingView : UserControl
    {
        public BillingView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            StockModel stock1 = new StockModel();
            stock1.MedName = medname.Text;
            BillBussiness bb = new BillBussiness();

            
            var list = bb.SearchData(stock1);
            grdlist.ItemsSource=list;

        }

        private void grdlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var row_list = GetDataGridRows(grdlist) ;
                foreach (DataGridRow single_row in row_list)
                {
                    if (single_row.IsSelected == true)
                    {
                        //Get your value over here
                        var data = grdlist.SelectedItem;
                        string name = (grdlist.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
                        medname.Text = name;

                        StockModel stock1 = new StockModel();
                        stock1.MedName = medname.Text;
                        BillBussiness bb = new BillBussiness();
                        var list =bb.fetchMedicine(stock1);
                        foreach(var item in list)
                        {
                            medid.Text = item.MedID.ToString();
                            unit.Text = item.UnitPrice.ToString();
                        }
                        


                    }
                }

            }
            catch(Exception ex) {
                Console.WriteLine("No data ");
            
            }
        }



        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grdList)
        {
            var itemsSource = grdlist.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grdlist.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

        
    }
}
        //public void bill_Load(Object sender, EventArgs e)
        //{
            
                          
                //try
                //{
                //List<StockModel> models = new List<StockModel>();
                //StockModel add = new StockModel();

                //    using (SqlConnection con = new SqlConnection("data source =.; database = PharmacyManagement; integrated security = SSPI"))
                //    {
                //       
                //        string cmdst = "select MedicineName,Price,StockAvailable from StockDetails where ExpiryDate > GetDate() " ;
                //        SqlCommand cmd = new SqlCommand(cmdst, con);
                //        con.Open();
                //        SqlDataReader read = cmd.ExecuteReader();

                //        DataTable dt = new DataTable();
                //        dt.Load(read);
                //        for (int i = 0; i < dt.Rows.Count; i++)
                //        {
                //            add.MedName = dt.Rows[i]["MedicineName"].ToString();


                //            models.Add(add);

                //        }
                  

                //}
                
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Unable to Open this page");
                //}


            
          //}

        
    



