using S3_MVVM_DataAccess;
using S3_NVVM_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace S3_MVVM.ViewModels
{
    public class SupplierViewModel: ViewModelBase<Supplier>
    {
        private Supplier selectedSupplier;

        public SupplierViewModel()
        {
            Suppliers = new ObservableCollection<Supplier>();
        }

        public ObservableCollection<Supplier> Suppliers { get; set; }
        public Supplier SelectedSupplier
        {
            get => selectedSupplier;
            set
            {
                selectedSupplier = value;
                OnPropertyChanged(nameof(SelectedSupplier));
            }
        }

        public override void LoadAll()
        {
            SupplierRepository supplierRepository = new SupplierRepository();
            IEnumerable<Supplier> suppliers = supplierRepository.GetAll();
            Suppliers.ReplaceWith(suppliers);
        }
    }
}