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
using System.Windows.Shapes;

namespace Magaz
{
    /// <summary>
    /// Логика взаимодействия для ActionWin.xaml
    /// </summary>
    public partial class ActionWin : Window
    {
        Entities context = new Entities();

        public ActionWin()
        {
            InitializeComponent();
            //ListProductGrid.ItemsSource = context.Product.ToList();
            ListProduct.ItemsSource = context.Product.ToList();            
        }

        private void btnMainPage_Click(object sender, RoutedEventArgs e)
        {
            ListProduct.ItemsSource = context.Product.ToList();
        }

        private void btnAppliances_Click(object sender, RoutedEventArgs e)
        {
            ListProduct.ItemsSource = context.Product.Where(i => i.IdProductCategory == 1).ToList();
        }

        private void btnSmartphone_Click(object sender, RoutedEventArgs e)
        {
            ListProduct.ItemsSource = context.Product.Where(i => i.IdProductCategory == 2).ToList();
        }

        private void btnTV_Click(object sender, RoutedEventArgs e)
        {
            ListProduct.ItemsSource = context.Product.Where(i => i.IdProductCategory == 3).ToList();
        }

        private void btnPC_Click(object sender, RoutedEventArgs e)
        {
            ListProduct.ItemsSource = context.Product.Where(i => i.IdProductCategory == 4).ToList();
        }

        private void btnOffice_Click(object sender, RoutedEventArgs e)
        {
            ListProduct.ItemsSource = context.Product.Where(i => i.IdProductCategory == 5).ToList();
        }

        private void btnAccessories_Click(object sender, RoutedEventArgs e)
        {
            ListProduct.ItemsSource = context.Product.Where(i => i.IdProductCategory == 6).ToList();
        }
    }
}
