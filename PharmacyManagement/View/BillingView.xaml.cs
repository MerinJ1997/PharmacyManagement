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
        protected int totalAmount = 0;
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
            grdlist.ItemsSource = list;
        }

        private void grdlist_SelectionChanged(object sender, SelectionChangedEventArgs e) //to give data from selected datagrid to textbox
        {
            try
            {
                var row_list = GetDataGridRows(grdlist);
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
                        var list = bb.fetchMedicine(stock1);
                        foreach (var item in list)
                        {
                            medid.Text = item.MedID.ToString();
                            unit.Text = item.UnitPrice.ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("No data ");
            }
        }
        public void Quantity_txtchanged(object sender, EventArgs e)
        {
            if (qty.Text != "")
            {
                float unitprice = float.Parse(unit.Text);
                Int64 quantity = Convert.ToInt64(qty.Text);
                float totalPrice = unitprice * quantity;
                txtPrice.Text = /*"Rs." +*/ totalPrice.ToString();
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
        public void CalculateGST()
        {
            StockModel stocks = new StockModel();  
            int Amnt = Convert.ToInt32(txtTotalAmnt.Text);
            gst = Amnt * 0.05;
            stocks.GST = gst;
            stocks.TotalAmount = Amnt;
            BillBussiness bill = new BillBussiness();
            bill.Bill(stocks);          // to save gst and total amount
        }
        public void SaveBillDetails()       //to save the details in grid
        {
            StockModel stocks = new StockModel();
            BillBussiness bussiness = new BillBussiness();
            foreach(var item in list)
            {                
                stocks.MedName = item.MedName;
                stocks.Quantity = item.Quantity;
                stocks.UnitPrice = item.UnitPrice;                
                stocks.Total = item.Total;
                bussiness.Bill2(stocks);
            }
             
        }
        private void PrintButton_Click_1(object sender, RoutedEventArgs e)
        {
            mainbill.Content = new BillReceipt();    
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                StockModel stock = new StockModel();
                BillBussiness bb = new BillBussiness();
                var row_list = GetDataGridRows(grdMD);
                foreach (DataGridRow single_row in row_list)
                {
                    if (single_row.IsSelected == true)
                    {
                        //Get your value over here
                        var datas = grdMD.SelectedItem;
                        int id = Convert.ToInt32((grdMD.SelectedCells[1].Column.GetCellContent(datas) as TextBlock).Text);
                        string name = (grdMD.SelectedCells[0].Column.GetCellContent(datas) as TextBlock).Text;
                        int qtyGRID = Convert.ToInt32((grdMD.SelectedCells[3].Column.GetCellContent(datas) as TextBlock).Text);
                        int price = Convert.ToInt32((grdMD.SelectedCells[4].Column.GetCellContent(datas)as TextBlock).Text);
                        stock.MedName = name;

                        var itemToRemove = list.ToList().Find(r => r.MedID == id);
                        if (itemToRemove != null)
                        {
                            list.Remove(itemToRemove);
                            totalAmount = totalAmount - price;
                            txtTotalAmnt.Text = totalAmount.ToString();
                            grdMD.ItemsSource = list;
                        }
                        var fetch = bb.fetchMedicine(stock);
                        foreach (var item in fetch)
                        {
                            stock.StockAvailable = qtyGRID + item.StockAvailable;
                            stock.MedName = name;
                            bb.UpdateQuantity(stock);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data to delete");
            }
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

                if (Qty <= stock)
                {
                    float UnitPrice = float.Parse(unit.Text);
                    string Total = txtPrice.Text;
                    stocks.MedID = MedId;
                    stocks.MedName = MedName;
                    stocks.UnitPrice = UnitPrice;
                    stocks.Total = Total;
                    stocks.Quantity = Convert.ToInt32(Qty);

                    list.Add(stocks);                //to add list to datagrid
                    grdMD.ItemsSource = list;
                    newStock = stock - Qty;
                        //stock = newStock;
                    stocks.MedName = medname.Text;
                    stocks.StockAvailable = Convert.ToInt32(newStock);
                    bb.UpdateQuantity(stocks);
                    MessageBox.Show("Stock Left: " + newStock);
                    totalAmount = totalAmount + Convert.ToInt32(txtPrice.Text);
                    txtTotalAmnt.Text = totalAmount.ToString();                    
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            CalculateGST();
            SaveBillDetails();
            MessageBox.Show("Saved Successfully");
        }

        public double gst;
        
        
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

        
    



