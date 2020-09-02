using S3_MVVM.ViewModels;
using S3_MVVM_DataAccess;

using S3_NVVM_Entities;

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
        private bool editIsOngoing;
        private bool additionIsOngoing;

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
            if(!editIsOngoing)
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
                    editIsOngoing = true;
                    buttonAddNewObject.IsEnabled = false;
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
            if(!additionIsOngoing)
            {
                buttonAllowEditing.IsEnabled = false;
                gridProductInfo.IsEnabled = true;
                productListBox.IsEnabled = false;
                productsViewModel.SelectedProduct = null;
                buttonAddNewObject.Content = "Cancel";
                buttonSaveNewObject.IsEnabled = true;
                additionIsOngoing = true;
            }
            else
            {
                StopAddition();
            }
        }

        private void ButtonSaveNewObject_Click(object sender, RoutedEventArgs e)
        {
            repo = new ProductRepository();
            int.TryParse(textBoxCategoryId.Text, out int categoryId);
            int.TryParse(textBoxSupplierId.Text, out int supplierId);
            decimal.TryParse(textBoxUnitPrice.Text, out decimal unitPrice);
            short.TryParse(textBoxUnitsInStock.Text, out short unitsInStock);
            short.TryParse(textBoxUnitsOnOrder.Text, out short unitsOnOrder);
            short.TryParse(textBoxReorderLevel.Text, out short reorderLevel);
            bool.TryParse(textBoxDiscontinued.Text, out bool discontinued);

            Product product = new Product()
            {
                ProductName = textBoxProductName.Text,
                CategoryId = categoryId,
                SupplierId = supplierId,
                QuantityPerUnit = textBoxQuantity.Text,
                UnitPrice = unitPrice,
                UnitsInStock = unitsInStock,
                UnitsOnOrder = unitsOnOrder,
                ReorderLevel = reorderLevel,
                Discontinued = discontinued,
            };
            repo.Add(product);
            productsViewModel.Products.Add(product);
            StopAddition();
        }

        private void StopEditing()
        {
            editIsOngoing = false;
            buttonAllowEditing.Content = "Edit";
            gridProductInfo.IsEnabled = false;
            productListBox.IsEnabled = true;
            buttonSaveEdit.IsEnabled = false;
            buttonAddNewObject.IsEnabled = true;
        }

        private void StopAddition()
        {
            additionIsOngoing = false;
            buttonAddNewObject.Content = "Add new object";
            productListBox.IsEnabled = true;
            buttonSaveNewObject.IsEnabled = false;
            buttonAllowEditing.IsEnabled = true;
            gridProductInfo.IsEnabled = false;
        }
    }
}