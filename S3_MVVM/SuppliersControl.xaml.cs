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
    /// Interaction logic for SuppliersControl.xaml
    /// </summary>
    public partial class SuppliersControl: UserControl
    {
        SupplierViewModel supplierViewModel;
        SupplierRepository repo;
        private bool isLoaded;
        private bool isEditing;

        public SuppliersControl()
        {
            InitializeComponent();
            supplierViewModel = DataContext as SupplierViewModel;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if(!isLoaded)
            {
                supplierViewModel.Initialize();
                isLoaded = true;
            }        
        }
        private void ButtonAllowEditing_Click(object sender, RoutedEventArgs e)
        {
            if(!isEditing)
            {
                if(supplierViewModel.SelectedSupplier == null)
                {
                    MessageBox.Show("You need to select a supplier before editing!");
                }
                else
                {
                    buttonAllowEditing.Content = "Cancel Edit";
                    gridSupplierInfo.IsEnabled = true;
                    supplierListBox.IsEnabled = false;
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
            repo = new SupplierRepository();
            repo.Update(supplierViewModel.SelectedSupplier);
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
            gridSupplierInfo.IsEnabled = false;
            supplierListBox.IsEnabled = true;
            buttonSaveEdit.IsEnabled = false;
        }
    }
}