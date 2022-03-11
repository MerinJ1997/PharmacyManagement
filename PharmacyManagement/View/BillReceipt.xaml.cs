﻿using System;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWelcomeView obj = new EmployeeWelcomeView();
            
        }

        private void Grid_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            
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
