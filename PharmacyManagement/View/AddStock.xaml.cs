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
    /// Interaction logic for AddStock.xaml
    /// </summary>
    public partial class AddStock : UserControl
    {
        public AddStock()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }


        void clear()
        {
            txtid.Text=string.Empty;
            txtname.Text=string.Empty;
            txtcompany.Text=string.Empty;
            txtprice.Text=string.Empty;
            dtpicker1.Text=string.Empty;
            txtstock.Text=string.Empty;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            clear();
        }
    }
}
