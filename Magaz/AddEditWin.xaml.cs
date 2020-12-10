using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static Magaz.AppData;

namespace Magaz
{
    /// <summary>
    /// Логика взаимодействия для AddEditWin.xaml
    /// </summary>
    public partial class AddEditWin : Window
    {
        string pathImage = null;
        public AddEditWin()
        {
            InitializeComponent();
            cmbProductCategory.ItemsSource = context.CategoryProduct.ToList();
            cmbProductCategory.DisplayMemberPath = "NameCategory";
            cmbProductCategory.SelectedIndex = 0;

            cmbUnitOfMeasure.ItemsSource = context.Measure.ToList();
            cmbUnitOfMeasure.DisplayMemberPath = "NameMeasure";
            cmbUnitOfMeasure.SelectedIndex = 0;
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile= new OpenFileDialog();

            if (openFile.ShowDialog() == true)
            {
                imageProduct.Source = new BitmapImage(new Uri(openFile.FileName));
                pathImage = openFile.FileName;
            }    
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            context.Product.Add(new Product
            {
                ProductImage = File.ReadAllBytes(pathImage),
                ProductName = txtProductName.Text,
                ProductDescription = txtProductDescription.Text,
                ProductPrice = Convert.ToDecimal(txtProductPrice.Text),
                CountProduct = Convert.ToInt32(txtProductCount.Text),

                IdProductCategory = 1,
                //context.CategoryProduct
                //.Where(i => i.NameCategory == cmbProductCategory.SelectedItem.ToString())
                //.Select(i => i.IdCategory).FirstOrDefault(),

                IdUnitOfMeasure = 1,
                //context.Measure.Where(i => i.NameMeasure == cmbUnitOfMeasure.SelectedItem.ToString())
                //.Select(i => i.IdMeasure).FirstOrDefault()
            }
            );
            context.SaveChanges();
            MessageBox.Show("Товар добавлен");
            this.Close();
        }
    }
}
