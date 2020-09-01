using S3_MVVM_DataAccess;
using S3_NVVM_Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace S3_MVVM.ViewModels
{
    public class ProductsViewModel: ViewModelBase<Product>
    {
        private Product selectedProduct;

        public ProductsViewModel()
        {
            Products = new ObservableCollection<Product>();
        }

        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public override void LoadAll()
        {
            ProductRepository productRepository = new ProductRepository();
            IEnumerable<Product> products = productRepository.GetAll();
            Products.ReplaceWith(products);
        }
    }
}