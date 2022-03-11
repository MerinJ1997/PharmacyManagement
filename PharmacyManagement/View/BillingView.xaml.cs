using BusinessLayer;
using EntityLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<StockModel> list = new ObservableCollection<StockModel>();
        protected int n, totalAmount = 0;
        protected Int64 stock, newStock;
        public BillingView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)  //to search- search button
        {
            StockModel stock1 = new StockModel();
            stock1.MedName = medname.Text;
            BillBussiness bb = new BillBussiness();
            var list = bb.SearchData(stock1);
            grdlist.ItemsSource=list;
        }

        private void grdlist_SelectionChanged(object sender, SelectionChangedEventArgs e) //to give data from selected datagrid to textbox
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
            catch(Exception ex) 
            {
                Console.WriteLine("No data ");
            }
        }
        public void Quantity_txtchanged(object sender, EventArgs e)
        {
            if (qty.Text != "")
            {
                Int64 unitprice = Convert.ToInt64(unit.Text);
                Int64 quantity = Convert.ToInt64(qty.Text);
                Int64 totalPrice = unitprice * quantity;
                txtPrice.Text = "Rs." + totalPrice.ToString();
            }
            else
            {
                txtPrice.Clear();
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
        private void PrintButton_Click_1(object sender, RoutedEventArgs e)
        {
            mainbill.Content = new BillReceipt();
        }
        
        private void AddButton_Click(object sender, RoutedEventArgs e) // Add to grid from text
        {
            StockModel stocks = new StockModel();
            stocks.MedName = medname.Text;
            BillBussiness bb = new BillBussiness();
            var data = bb.fetchMedicine(stocks);
            foreach (var item in data)
            {
                stock = item.StockAvailable;
            }

            int MedId = Convert.ToInt32(medid.Text);
            string MedName = medname.Text;
            if (qty.Text != "")
            {
                int Qty = Convert.ToInt32(qty.Text);
                float UnitPrice = float.Parse(unit.Text);
                string Total = txtPrice.Text;
                //foreach (var item in list)            //to add existing medicine again
                //{
                //    if (item.MedID == MedId && item.MedName == MedName)
                //    {
                //        var x = grdMD.SelectedItem;
                //        int quantity = Convert.ToInt32((grdMD.SelectedCells[0].Column.GetCellContent(x) as TextBlock).Text);
                //        Qty = Qty + quantity;
                //    }
                //}
                stocks.MedID = MedId;
                stocks.MedName = MedName;
                stocks.UnitPrice = UnitPrice;
                stocks.Total = Total;
                stocks.Quantity = Convert.ToInt32(Qty);

                list.Add(stocks);                //to add list to datagrid
                grdMD.ItemsSource = list;

                if (Qty <= stock)
                {
                    newStock = stock - Qty;
                    //stock = newStock;
                    stocks.MedName = medname.Text;
                    stocks.StockAvailable = Convert.ToInt32(newStock);
                    bb.UpdateQuantity(stocks);
                    MessageBox.Show("Stock Left: " + newStock);
                }
                else
                {
                    MessageBox.Show("Exceeded stock limit. Please enter value less than " + stock);
                }
            }
            else
            {
                MessageBox.Show("Enter values");
            }
            Clear();
        }
        private void grdmedlistChanged(object sender, SelectionChangedEventArgs e)   //To delete from row
        {
            try
            {
                var row_list = GetDataGridRows(grdMD);
                foreach (DataGridRow single_row in row_list)
                {
                    if (single_row.IsSelected == true)
                    {
                        //Get your value over here
                        StockModel stock = new StockModel();
                        var data = grdMD.SelectedItem;
                        int id = Convert.ToInt32((grdMD.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text);
                        //if(stock.MedID == id)
                        //{
                        //    list.Remove(stock.MedID);
                        //}

                        //var list2 = list1.ToList();
                        //var itemToRemove = list.Find(r => r.MedID == id);
                        //if (itemToRemove != null)
                        //{
                        //    list.Remove(itemToRemove);
                        //}

                        grdMD.ItemsSource = list;
                        //var query = from x in list1
                        //            where x => x.MedID == id
                        //            select x;
                        //list1.RemoveAt();
                        //grdmed.Items.Remove(row_list);
                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
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

        
    



