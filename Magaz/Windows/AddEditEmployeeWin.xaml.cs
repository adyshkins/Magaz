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
    /// Логика взаимодействия для AddEditEmployeeWin.xaml
    /// </summary>
    public partial class AddEditEmployeeWin : Window
    {
        private Employee AddEmployee { get; set; }// для добавления пользователя

        public AddEditEmployeeWin()
        {
            InitializeComponent();
            cmbEmployeeRole.ItemsSource = context.Role.ToList();
            cmbEmployeeRole.DisplayMemberPath = "NameRole";
            cmbEmployeeRole.SelectedIndex = 0;
            AddEmployee = new Employee();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Поле Фамилия не может быть пустым", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Поле Имя не может быть пустым", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Поле Логин не может быть пустым", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Поле Логин не может быть пустым", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            var result = MessageBox.Show("Вы уверены?","Добавление нового сотрудника", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                AddEmployee.LastName = txtLastName.Text;
                AddEmployee.FirstName = txtFirstName.Text;
                AddEmployee.MiddleName = txtMiddleName.Text;
                AddEmployee.Login = txtLogin.Text;
                AddEmployee.Password = txtPassword.Text;
                AddEmployee.IdRole = 1;

                context.Employee.Add(AddEmployee);
                context.SaveChanges();
                MessageBox.Show("Сотрудник добавлен");
                this.Close();
            }
            
        }

        private void txtLastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
                e.Handled = HelperClass.stringGen.FIO().IndexOf(e.Text) < 0;            
        }
    }
}
