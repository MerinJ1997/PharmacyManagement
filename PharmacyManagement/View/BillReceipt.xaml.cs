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
    /// Interaction logic for BillReceipt.xaml
    /// </summary>
    public partial class BillReceipt : UserControl
    {
        public BillReceipt()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    EmployeeWelcomeView obj = new EmployeeWelcomeView();
        //}

        public void Bill_Load(Object sender, EventArgs e)
        {
            List<StockModel> sm = new List<StockModel>();
            //StockModel model = new StockModel();
            BillBussiness billBussiness = new BillBussiness();
            sm = billBussiness.GetBillDet();
            grdReceipt.ItemsSource = sm;
            foreach (var stock in sm)
            {                
                int qty = stock.Quantity;
                txtInvoice.Text = stock.InvoiceNo.ToString();
                txtDate.Text = stock.Date.ToString();
                txtSubTotal.Text = stock.TotalAmount.ToString();
                txtGST.Text = stock.GST.ToString();
                txtTotal.Text ="Rs. " + (stock.TotalAmount + stock.GST).ToString();
            }
        }

        private void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(this, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
