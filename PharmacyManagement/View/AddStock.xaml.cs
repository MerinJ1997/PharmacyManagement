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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            clear();
        }
        void clear()
        {
            txtname.Text =String.Empty;
            txtid.Text =String.Empty;
            txtcompany.Text =String.Empty;  
            txtprice.Text =String.Empty;
            txtstock.Text =String.Empty;
            dtpicker1.Text =String.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }
    }
}
