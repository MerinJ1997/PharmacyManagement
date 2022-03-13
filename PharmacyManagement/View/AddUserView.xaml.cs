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
    /// Interaction logic for AddUserView.xaml
    /// </summary>
    public partial class AddUserView : UserControl
    {
        public AddUserView()
        {
            InitializeComponent();
        }

        void clear()
        {
            txtname.Text = string.Empty;
            txtaddress.Text = string.Empty;
            txtphno.Text = string.Empty;
            txtemail.Text = string.Empty;
            cmbgender.Text = string.Empty;
            Age.Text = string.Empty;
            username.Text = String.Empty;
            password.Text = String.Empty;
            role.Text = string.Empty;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clear();

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }
    }
}
