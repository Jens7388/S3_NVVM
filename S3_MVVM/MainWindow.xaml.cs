using S3_MVVM;
using System;
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

namespace S3_NVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        ProductsControl productsControl;
        SuppliersControl suppliersControl;

        public MainWindow()
        {
            InitializeComponent();
            productsControl = new ProductsControl();
            suppliersControl = new SuppliersControl();
            Display(productsControl);
        }

        private void Navigation_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if(button != null)
            {
                switch(button.Uid)
                {
                    case "1":
                        Display(productsControl);
                        break;
                    case "2":
                        Display(suppliersControl);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Display(UserControl userControl)
        {
            displayedUserControl.Content = userControl;
        }
    }
}