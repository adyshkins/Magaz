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
using static Magaz.AppData;

namespace Magaz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class StartWin : Window
    {
        public StartWin()
        {
            InitializeComponent();            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            Employee user = context.Employee.ToList().Where(i => i.Login == txtLogin.Text && i.Password == pswPassword.Password).FirstOrDefault();

            if (user != null)
            {
                ActionWin actionWin = new ActionWin(user);
                this.Hide();
                actionWin.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Логин или пароль введены неверно");
            }
          
        }
    }
}
