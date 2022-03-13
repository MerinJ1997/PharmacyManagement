using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for StockView.xaml
    /// </summary>
    public partial class StockView : UserControl

    {
        public int id { get; set; }
        public StockView()
        {
            InitializeComponent();
        }
        Regex rName = new Regex(@"^[a-zA-Z]+$");
        Regex rUnit = new Regex(@"^[0-9]+$");
        private void EditStock(Object sender, RoutedEventArgs e)
        {
            id = (DataGrid.SelectedItem as StockModel).MedID;
            medname.Text = (DataGrid.SelectedItem as StockModel).MedName;
            companyname.Text = (DataGrid.SelectedItem as StockModel).Company;
            stock.Text = (DataGrid.SelectedItem as StockModel).StockAvailable.ToString();
            Price.Text=(DataGrid.SelectedItem as StockModel).UnitPrice.ToString();
            dtpicker.Text= (DataGrid.SelectedItem as StockModel).Expiry.ToString();

        }

        void ClearTextBox()
        {
            medname.Text = string.Empty;
            companyname.Text = string.Empty;
            stock.Text = string.Empty;
            Price.Text = string.Empty;
            dtpicker.Text = string.Empty;
        }


        private void DeleteStock(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.Items.Count > 0)
                {
                    var value = (DataGrid.SelectedItem as StockModel).MedID;
                    StockModel Model = new StockModel();
                    UpdateStockBusiness add = new UpdateStockBusiness();
                    Model.MedID = value;
                    add.DeleteData(Model);
                    MessageBox.Show("User Data Deleted :" + Model.MedID);
                    Refresh();
                }
                else
                {
                    MessageBox.Show("No Data available for Delete:??");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        void Refresh()
        {
            UpdateStockBusiness add = new UpdateStockBusiness();
            DataGrid.ItemsSource = add.GetStockToDisplay();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StockModel stockModel = new StockModel();
                id = (DataGrid.SelectedItem as StockModel).MedID;
                string Name = medname.Text;
                string UnitPrice = Price.Text;
                string StockAvailable = stock.Text;
                string Expiry = dtpicker.Text;
                if (Name != null && UnitPrice != null && StockAvailable != null)
                {
                    if (Name.Length > 0)
                    {
                        if (!rName.IsMatch(Name))
                        {
                            MessageBox.Show("Invalid Medicine Name");
                        }
                        else if (!rUnit.IsMatch(UnitPrice))
                        {
                            MessageBox.Show("Invalid Price");
                        }
                        else if (!rUnit.IsMatch(StockAvailable))
                        {
                            MessageBox.Show("Invalid Price");
                        }
                        else
                        {
                            stockModel.MedID = id;
                            stockModel.MedName = medname.Text;
                            stockModel.StockAvailable = Int32.Parse(stock.Text);
                            stockModel.UnitPrice = float.Parse(Price.Text);
                            stockModel.Expiry = Convert.ToDateTime(dtpicker.Text);
                            stockModel.Company = companyname.Text;
                            UpdateStockBusiness usb = new UpdateStockBusiness();
                            usb.UpdateData(stockModel);
                            MessageBox.Show("Stock Details is Updated");
                        }
                    }
                }
                Refresh();
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter Values");
            }
            
        }
    }
}
    
    
    

