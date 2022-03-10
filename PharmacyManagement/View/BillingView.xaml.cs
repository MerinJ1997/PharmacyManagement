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
        public void Quantity_txtchanged(object sender, EventArgs e)
        {
            if (qty.Text != "")
            {
                Int64 unitprice = Convert.ToInt64(unit.Text);
                Int64 quantity = Convert.ToInt64(qty.Text);
                Int64 totalPrice =unitprice * quantity;
                txtPrice.Text = "Rs." + totalPrice.ToString();
            }
            else
            {
                txtPrice.Clear();
            }
        }
        protected int n, totalAmount = 0;
        protected Int64 stock, newStock;

        private void ClearButton(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            medname.Text = string.Empty;
            medid.Text = string.Empty;
            unit.Text = string.Empty;
            qty.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }
        
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            StockModel stocks = new StockModel();
            stocks.MedName = medname.Text;
            BillBussiness bb = new BillBussiness();
            var data = bb.fetchMedicine(stocks);
            foreach(var item in data)
            {
                stock = item.StockAvailable;
            }

            int MedId =Convert.ToInt32( medid.Text);
            string MedName=medname.Text;
            Int64 Qty = Convert.ToInt64(qty.Text);
            float UnitPrice =float.Parse( unit.Text);
            string Total=txtPrice.Text;
            List<StockModel> list = new List<StockModel>();
            stocks.MedID = MedId;
            stocks.MedName = MedName;
            stocks.UnitPrice = UnitPrice;
            stocks.Total = Total;
            stocks.Quantity=Convert.ToInt32( Qty);
            list.Add(stocks);
            grdmed.ItemsSource=list;
            if (Qty <= stock)
            {
                newStock = stock - Qty;
                //stock = newStock;
                stocks.MedName = medname.Text;
                stocks.StockAvailable =Convert.ToInt32(newStock);
                bb.UpdateQuantity(stocks);
                MessageBox.Show("Stock Left: " + newStock);
            }
            else
            {
                MessageBox.Show("Exceeded stock limit. Please enter value less than " + stock);
            }

            Clear();
        }
        void Refresh()
        {


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

        
    



