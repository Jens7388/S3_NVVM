using S3_MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S3_MVVM
{
    /// <summary>
    /// Interaction logic for SuppliersControl.xaml
    /// </summary>
    public partial class SuppliersControl: UserControl
    {
        SupplierViewModel supplierViewModel;

        public SuppliersControl()
        {
            InitializeComponent();
            supplierViewModel = DataContext as SupplierViewModel;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            supplierViewModel.Initialize();
        }
    }
}
