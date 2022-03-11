using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for StockView.xaml
    /// </summary>
    public partial class StockView : UserControl

    {
        public int id { get; set; }
        public StockView()
        {
            InitializeComponent();
        }

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
            StockModel stockModel = new StockModel();
            stockModel.MedID = id;
            stockModel.MedName = medname.Text;
            stockModel.StockAvailable = Int32.Parse(stock.Text);
            stockModel.UnitPrice = float.Parse(Price.Text);
            stockModel.Expiry  =Convert.ToDateTime(dtpicker.Text);

            stockModel.Company=companyname.Text;
            UpdateStockBusiness usb = new UpdateStockBusiness();
            usb.UpdateData(stockModel);
            MessageBox.Show("Stock Details is Updated");
            Refresh();
            ClearTextBox();






            
        }

    }
}
    
    
    

