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
        Entities context = new Entities(); // переместить

        List<Product> productList = new List<Product>(); // список для фильтра

        public ActionWin()
        {
            InitializeComponent();

            productList = context.Product.ToList();
            ListProduct.ItemsSource = productList;
        }

        void BrushButton()
        {
            btnMainPage.Background = Brushes.LightGray;
            btnAppliances.Background = Brushes.LightGray;
            btnSmartphone.Background = Brushes.LightGray;
            btnTV.Background = Brushes.LightGray;
            btnPC.Background = Brushes.LightGray;
            btnOffice.Background = Brushes.LightGray;
            btnAccessories.Background = Brushes.LightGray;

            btnMainPage.Style = null;
        }

        private void btnMainPage_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = context.Product.ToList();
            ListProduct.ItemsSource = productList;
            btnMainPage.Background = Brushes.Red;
        }

        private void btnAppliances_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = context.Product.Where(i => i.IdProductCategory == 1).ToList();
            ListProduct.ItemsSource = productList;
            btnAppliances.Background = Brushes.Red;

        }

        private void btnSmartphone_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = context.Product.Where(i => i.IdProductCategory == 2).ToList();
            ListProduct.ItemsSource = productList;
            btnSmartphone.Background = Brushes.Red;

        }

        private void btnTV_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = context.Product.Where(i => i.IdProductCategory == 3).ToList();
            ListProduct.ItemsSource = productList;
            btnTV.Background = Brushes.Red;

        }

        private void btnPC_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = context.Product.Where(i => i.IdProductCategory == 4).ToList();
            ListProduct.ItemsSource = productList;
            btnPC.Background = Brushes.Red;

        }

        private void btnOffice_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = context.Product.Where(i => i.IdProductCategory == 5).ToList();
            ListProduct.ItemsSource = productList;
            btnOffice.Background = Brushes.Red;

        }

        private void btnAccessories_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = context.Product.Where(i => i.IdProductCategory == 6).ToList();
            ListProduct.ItemsSource = productList;
            btnAccessories.Background = Brushes.Red;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e) // поиск товаров по имени и описанию
        {
            ListProduct.ItemsSource = productList
                .Where(i => i.ProductName.Contains(txtSearch.Text))
                .Where(i => i.ProductDescription.Contains(txtSearch.Text));
        }
    }
}
