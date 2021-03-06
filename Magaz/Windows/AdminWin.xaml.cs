﻿using System;
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

namespace Magaz.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWinxaml.xaml
    /// </summary>
    public partial class AdminWin : Window
    {
        public AdminWin()
        {
            InitializeComponent();
            txbUser.Text = $"{HelperClass.DataUser.User.LastName} {HelperClass.DataUser.User.FirstName} {HelperClass.DataUser.User.MiddleName}";
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            ActionWin actionWin = new ActionWin();
            this.Hide();
            actionWin.ShowDialog();
            this.Show();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWin employeeWin = new EmployeeWin();
            this.Hide();
            employeeWin.ShowDialog();
            this.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VendorWin vendor = new VendorWin();
            this.Hide();
            vendor.ShowDialog();
            this.Show();
        }
    }
}
