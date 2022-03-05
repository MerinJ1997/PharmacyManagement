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
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        public EmployeeView()
        {
            InitializeComponent();
            Refresh();
        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.Items.Count > 0)
                {
                    var value = (DataGrid.SelectedItem as AddUserDetailsModel).ID;
                    AddUserDetailsModel Model = new AddUserDetailsModel();
                    AddUserBusiness add = new AddUserBusiness();
                    Model.ID = value;
                    add.DeleteData(Model);
                    MessageBox.Show("User Data Deleted :" + Model.ID);
                    Refresh();
                }
                else
                {
                    MessageBox.Show("No User available for Delete:??");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void Refresh()
        {
            AddUserBusiness add = new AddUserBusiness();
            DataGrid.ItemsSource = add.GetUserDetails();
        }
    }

}
