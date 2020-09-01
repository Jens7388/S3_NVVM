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
    public class SupplierViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Supplier selectedSupplier;

        public SupplierViewModel()
        {
            Suppliers = new ObservableCollection<Supplier>();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

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

        public void Initialize()
        {
            LoadAllSuppliers();
        }

        private void LoadAllSuppliers()
        {
            SupplierRepository supplierRepository = new SupplierRepository();
            IEnumerable<Supplier> suppliers = supplierRepository.GetAll();
            Suppliers.ReplaceWith(suppliers);
        }
    }
}
