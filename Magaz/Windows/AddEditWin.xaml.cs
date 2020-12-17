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

        private Product AddProduct { get; }

        private Product productEdit;

        private bool _isEdit;

        public AddEditWin()
        {
            InitializeComponent();
            cmbProductCategory.ItemsSource = context.CategoryProduct.ToList();
            cmbProductCategory.DisplayMemberPath = "NameCategory";
            cmbProductCategory.SelectedIndex = 0;

            cmbUnitOfMeasure.ItemsSource = context.Measure.ToList();
            cmbUnitOfMeasure.DisplayMemberPath = "NameMeasure";
            cmbUnitOfMeasure.SelectedIndex = 0;

            AddProduct = new Product();
            _isEdit = false;
        }

        public AddEditWin(Product product)
        {
            InitializeComponent();
            productEdit = product;
            _isEdit = true;
            // заполнение полей данными
            cmbProductCategory.ItemsSource = context.CategoryProduct.ToList();
            cmbProductCategory.DisplayMemberPath = "NameCategory";

            cmbUnitOfMeasure.ItemsSource = context.Measure.ToList();
            cmbUnitOfMeasure.DisplayMemberPath = "NameMeasure";


            txtProductName.Text = product.ProductName;
            txtProductDescription.Text = product.ProductDescription;
            txtProductPrice.Text = product.ProductPrice.ToString();
            txtProductCount.Text = product.CountProduct.ToString();
            cmbProductCategory.SelectedItem = context.CategoryProduct.Where(i => i.IdCategory == product.IdProductCategory).ToList().FirstOrDefault();
            cmbUnitOfMeasure.SelectedItem = context.Measure.Where(i => i.IdMeasure == product.IdUnitOfMeasure).ToList().FirstOrDefault();

            // Выгрузка фото из базы
            if (product.ProductImage != null)
            {
                using (MemoryStream stream = new MemoryStream(product.ProductImage))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    imageProduct.Source = bitmapImage;
                }
            }
        }

        // Выбор фото
        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == true)
            {
                imageProduct.Source = new BitmapImage(new Uri(openFile.FileName));
                pathImage = openFile.FileName;
            }
        }

        //Выход
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Добавить (Изменить) продукт
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // проверка на пустоту
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Поле название товара не может быть пустым", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProductPrice.Text))
            {
                MessageBox.Show("Поле Количество товара не может быть пустым", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProductCount.Text))
            {
                MessageBox.Show("Поле Цена товара не может быть пустым", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            try
            {
                if (_isEdit == false)
                {
                    // если нет фото передаём null
                    if (pathImage != null)
                    {
                        AddProduct.ProductImage = File.ReadAllBytes(pathImage);
                    }
                    else
                    {
                        AddProduct.ProductImage = null;
                    }

                    // если не выбрали фото, выводим вопрос с подтверждением
                    if (pathImage == null)
                    {
                        var resMess = MessageBox.Show("Фото не выбрано. Сохранить товар без фото?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resMess == MessageBoxResult.No)
                        {
                            return;
                        }
                    }

                    AddProduct.ProductName = txtProductName.Text;
                    AddProduct.ProductDescription = txtProductDescription.Text;
                    AddProduct.ProductPrice = Convert.ToDecimal(txtProductPrice.Text);
                    AddProduct.CountProduct = Convert.ToInt32(txtProductCount.Text);

                    AddProduct.IdProductCategory = context.CategoryProduct
                    .Where(i => i.NameCategory == cmbProductCategory.Text)
                    .Select(i => i.IdCategory).FirstOrDefault();

                    AddProduct.IdUnitOfMeasure = context.Measure.Where(i => i.NameMeasure == cmbUnitOfMeasure.Text)
                    .Select(i => i.IdMeasure).FirstOrDefault();

                    context.Product.Add(AddProduct); // добавление товара
                    context.SaveChanges();
                    MessageBox.Show($"Товар {txtProductName.Text} добавлен");
                }

                if (_isEdit == true)
                {
                    // изм. товара

                    // если нет фото передаём null
                    if (pathImage != null)
                    {
                        productEdit.ProductImage = File.ReadAllBytes(pathImage); // переделать!!!!!!!!!!!!
                    }
                    else
                    {
                        productEdit.ProductImage = null;
                    }

                    // если не выбрали фото, выводим вопрос с подтверждением


                    productEdit.ProductName = txtProductName.Text;
                    productEdit.ProductDescription = txtProductDescription.Text;
                    productEdit.ProductPrice = Convert.ToDecimal(txtProductPrice.Text);
                    productEdit.CountProduct = Convert.ToInt32(txtProductCount.Text);

                    productEdit.IdProductCategory = context.CategoryProduct
                    .Where(i => i.NameCategory == cmbProductCategory.Text)
                    .Select(i => i.IdCategory).FirstOrDefault();

                    productEdit.IdUnitOfMeasure = context.Measure.Where(i => i.NameMeasure == cmbUnitOfMeasure.Text)
                    .Select(i => i.IdMeasure).FirstOrDefault();

                    context.SaveChanges();

                    MessageBox.Show("Данные успешно сохранены");

                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

           
        }

        // запрет ввода всех символов кроме цифр и точки в поле цена
        private void txtProductPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789.".IndexOf(e.Text) < 0;
        }

        // запрет ввода всех символов кроме цифр и точки в поле Количество
        private void txtProductCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }
    }
}
