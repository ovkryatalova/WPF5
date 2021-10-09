using System.Linq;
using System.Windows;

namespace CreateAuthorize
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        DBContainer db = new DBContainer();
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Password == "" || lastname.Text == "" || firstname.Text == "" || middlename.Text == "")
            {
                MessageBox.Show("Ошибка пустые поля"); return;
            }
            if (db.Users.Select(item => item.Login).Contains(login.Text))
            {
                MessageBox.Show("Такой логин существует в системе"); return;
            }
            User newUser = new User()
            {
                Login = login.Text,
                Password = password.Password,
                LastName = lastname.Text,
                FirstName = firstname.Text,
                MiddleName = middlename.Text
            };
            db.Users.Add(newUser);
            db.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрировались!");
            AuthorizationWindow aw = new AuthorizationWindow();
            aw.Show();
            this.Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow aw = new AuthorizationWindow();
            aw.Show();
            this.Close();
        }
    }
}
