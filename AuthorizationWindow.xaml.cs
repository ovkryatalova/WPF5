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
using System.Web;





namespace CreateAuthorize
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        DBContainer db;
        public AuthorizationWindow()
        {
            InitializeComponent();
            db = new DBContainer();
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            RegistrationWindow rw = new RegistrationWindow();
            rw.Show();
            this.Close();
        }

        private void AuthorizationClick(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Password == "")
            {
                MessageBox.Show("Ошибка пустые поля"); return;
            }
            if (db.Users.Select(item => item.Login + " " + item.Password).Contains(login.Text + " " + password.Password))
            {
                MessageBox.Show("Вы авторизированы");
            }
            else
            {
                MessageBox.Show("Ошибка логина/пароля");
            }
        }
    }
}
