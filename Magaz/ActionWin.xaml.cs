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
using System.Collections.ObjectModel;
using static Magaz.AppData;

namespace Magaz
{
    /// <summary>
    /// Логика взаимодействия для ActionWin.xaml
    /// </summary>
    public partial class ActionWin : Window
    {
        ObservableCollection<Product> productList = new ObservableCollection<Product>();

        public ActionWin()
        {
            InitializeComponent();

            productList = new ObservableCollection<Product>(context.Product);
            ListProduct.ItemsSource = productList;

        }

        void BrushButton() // переделать
        {
            btnMainPage.BorderThickness = new Thickness(0);
            btnAppliances.BorderThickness = new Thickness(0);
            btnSmartphone.BorderThickness = new Thickness(0);
            btnTV.BorderThickness = new Thickness(0);
            btnPC.BorderThickness = new Thickness(0);
            btnOffice.BorderThickness = new Thickness(0);
            btnAccessories.BorderThickness = new Thickness(0);
            btnMainPage.BorderThickness = new Thickness(0);
        }

        private void btnMainPage_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = new ObservableCollection<Product>(context.Product);
            ListProduct.ItemsSource = productList;

            btnMainPage.BorderThickness = new Thickness(2);
            btnMainPage.BorderBrush = Brushes.Red;
        }

        private void btnAppliances_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = new ObservableCollection<Product>(context.Product.Where(i => i.IdProductCategory == 1));
            ListProduct.ItemsSource = productList;

            btnAppliances.BorderThickness = new Thickness(2);
            btnAppliances.BorderBrush = Brushes.Red;
        }

        private void btnSmartphone_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = new ObservableCollection<Product>(context.Product.Where(i => i.IdProductCategory == 2));
            ListProduct.ItemsSource = productList;

            btnSmartphone.BorderThickness = new Thickness(2);
            btnSmartphone.BorderBrush = Brushes.Red;

        }

        private void btnTV_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = new ObservableCollection<Product>(context.Product.Where(i => i.IdProductCategory == 3).ToList());
            ListProduct.ItemsSource = productList;

            btnTV.BorderThickness = new Thickness(2);
            btnTV.BorderBrush = Brushes.Red;
        }

        private void btnPC_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = new ObservableCollection<Product>(context.Product.Where(i => i.IdProductCategory == 4));
            ListProduct.ItemsSource = productList;

            btnPC.BorderThickness = new Thickness(2);
            btnPC.BorderBrush = Brushes.Red;
        }

        private void btnOffice_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = new ObservableCollection<Product>(context.Product.Where(i => i.IdProductCategory == 5));
            ListProduct.ItemsSource = productList;

            btnOffice.BorderThickness = new Thickness(2);
            btnOffice.BorderBrush = Brushes.Red;

        }

        private void btnAccessories_Click(object sender, RoutedEventArgs e)
        {
            BrushButton();
            productList = new ObservableCollection<Product>(context.Product.Where(i => i.IdProductCategory == 6));
            ListProduct.ItemsSource = productList;

            btnAccessories.BorderThickness = new Thickness(2);
            btnAccessories.BorderBrush = Brushes.Red;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e) // поиск товаров по имени и описанию
        {
            ListProduct.ItemsSource = productList
                .Where(i => i.ProductName.Contains(txtSearch.Text)
                || i.ProductDescription.Contains(txtSearch.Text)
                || i.IdProduct.ToString() == txtSearch.Text);
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditWin addEditWin = new AddEditWin();
            this.Opacity = 0.3;
            addEditWin.ShowDialog();
            this.Opacity = 1;
            ListProduct.ItemsSource = new ObservableCollection<Product>(context.Product);

        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ListProduct.SelectedItem is Product product)
            {
                AddEditWin addEditWin = new AddEditWin(product);
                this.Opacity = 0.3;
                addEditWin.ShowDialog();
            }
            this.Opacity = 1;
            ListProduct.ItemsSource = new ObservableCollection<Product>(context.Product);

        }
    }
}
