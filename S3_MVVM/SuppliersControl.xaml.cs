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
    /// Interaction logic for SuppliersControl.xaml
    /// </summary>
    public partial class SuppliersControl: UserControl
    {
        SupplierViewModel supplierViewModel;
        SupplierRepository repo;
        private bool isLoaded;
        private bool editIsOngoing;
        private bool additionIsOngoing;

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
            if(!editIsOngoing)
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
            repo = new SupplierRepository();
            repo.Update(supplierViewModel.SelectedSupplier);
            StopEditing();
        }

        private void ButtonAddNewObject_Click(object sender, RoutedEventArgs e)
        {
            if(!additionIsOngoing)
            {
                buttonAllowEditing.IsEnabled = false;
                gridSupplierInfo.IsEnabled = true;
                supplierListBox.IsEnabled = false;
                supplierViewModel.SelectedSupplier = null;
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
            {
                repo = new SupplierRepository();

                Supplier supplier = new Supplier()
                {
                    CompanyName = textBoxCompanyName.Text,
                    ContactName = textBoxContactName.Text,
                    Address = textBoxAddress.Text,
                    City = textBoxCity.Text,
                    Region = textBoxRegion.Text,
                    PostalCode = textBoxPostalCode.Text,
                    Country = textBoxCountry.Text,
                    Phone = textBoxPhone.Text,
                    Fax = textBoxFax.Text,
                    HomePage = textBoxHomePage.Text,
                };
                repo.Add(supplier);
                supplierViewModel.Suppliers.Add(supplier);
                StopAddition();
            }
        }

        private void StopEditing()
        {
            editIsOngoing = false;
            buttonAllowEditing.Content = "Edit";
            gridSupplierInfo.IsEnabled = false;
            supplierListBox.IsEnabled = true;
            buttonSaveEdit.IsEnabled = false;
            buttonAddNewObject.IsEnabled = true;
        }

        private void StopAddition()
        {
            additionIsOngoing = false;
            buttonAddNewObject.Content = "Add new object";
            supplierListBox.IsEnabled = true;
            buttonSaveNewObject.IsEnabled = false;
            buttonAllowEditing.IsEnabled = true;
            gridSupplierInfo.IsEnabled = false;
        }
    }
}