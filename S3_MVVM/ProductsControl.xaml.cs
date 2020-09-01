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
    /// Interaction logic for ProductsControl.xaml
    /// </summary>
    public partial class ProductsControl: UserControl
    {
        ProductsViewModel productsViewModel;

        public ProductsControl()
        {
            InitializeComponent();
            productsViewModel = DataContext as ProductsViewModel;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            productsViewModel.Initialize();
        }
    }
}
