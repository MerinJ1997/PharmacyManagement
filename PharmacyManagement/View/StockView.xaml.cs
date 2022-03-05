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
        public StockView()
        {
            InitializeComponent();
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
            void Refresh()
            {
                UpdateStockBusiness add = new UpdateStockBusiness();
                DataGrid.ItemsSource = add.GetStockToDisplay();
            }
        }

    }
}
    
    
    

