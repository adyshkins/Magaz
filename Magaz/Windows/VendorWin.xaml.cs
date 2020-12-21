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
using static Magaz.AppData;

namespace Magaz.Windows
{
    /// <summary>
    /// Логика взаимодействия для VendorWin.xaml
    /// </summary>
    public partial class VendorWin : Window
    {
        public VendorWin()
        {
            InitializeComponent();
            ListVendor.ItemsSource = context.Vendor.ToList();

            txtNameEmpl.Text = $" {HelperClass.DataUser.User.LastName} {HelperClass.DataUser.User.FirstName} {HelperClass.DataUser.User.MiddleName}";

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListVendor.SelectedItem is Vendor vendor)
            {
                var result = MessageBox.Show("Удаление поставщика", "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    context.Vendor.Remove(context.Vendor.Find(vendor.IdVendor));
                    context.SaveChanges();
                    MessageBox.Show("Запись удалена успешно");
                    ListVendor.ItemsSource = context.Vendor.ToList();
                }
               
            }
            else
            {
                MessageBox.Show("Запись не выбрана");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditVendorWin addEditVendorWin = new AddEditVendorWin();
            this.Hide();
            addEditVendorWin.ShowDialog();
            ListVendor.ItemsSource = context.Vendor.ToList();
            this.Show();            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ListVendor.SelectedItem is Vendor vendor)
            {
                AddEditVendorWin addEditVendorWin = new AddEditVendorWin(vendor);
                this.Hide();
                addEditVendorWin.ShowDialog();
                ListVendor.ItemsSource = context.Vendor.ToList();
                this.Show();
            }
            else
            {
                MessageBox.Show("Запись не выбрана");
            }
        }
    }
}
