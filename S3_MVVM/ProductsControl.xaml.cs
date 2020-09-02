using S3_MVVM.ViewModels;
using S3_MVVM_DataAccess;
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
        ProductRepository repo;
        private bool isLoaded;
        private bool isEditing;

        public ProductsControl()
        {
            InitializeComponent();
            productsViewModel = DataContext as ProductsViewModel;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if(!isLoaded)
            {
                productsViewModel.Initialize();
                isLoaded = true;
            }
        }
        private void ButtonAllowEditing_Click(object sender, RoutedEventArgs e)
        {
            if(!isEditing)
            {
                if(productsViewModel.SelectedProduct == null)
                {
                    MessageBox.Show("You need to select a product before editing!");
                }
                else
                {
                    buttonAllowEditing.Content = "Cancel Edit";
                    gridProductInfo.IsEnabled = true;
                    productListBox.IsEnabled = false;
                    buttonSaveEdit.IsEnabled = true;
                    isEditing = true;
                }
            }
            else
            {
                StopEditing();
            }
        }

        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            repo = new ProductRepository();
            repo.Update(productsViewModel.SelectedProduct);
            StopEditing();
        }

        private void ButtonAddNewObject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSaveNewObject_Click(object sender, RoutedEventArgs e)
        {

        }
        private void StopEditing()
        {
            isEditing = false;
            buttonAllowEditing.Content = "Edit";
            gridProductInfo.IsEnabled = false;
            productListBox.IsEnabled = true;
            buttonSaveEdit.IsEnabled = false;
        }
    }
}