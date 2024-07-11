using ProjectQA.Data;
using ProjectQA.Services;
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

namespace ProjectQA
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private readonly AuthService _authService;

        public RegistrationWindow()
        {
            InitializeComponent();
            _authService = new AuthService(new DataContext());
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;
            string email = EmailBox.Text;
            string role = RoleBox.Text;

          
            if (_authService.UserExists(login))
            {
                ErrorMessageTextBlock.Text = "User with this login already exists.";
                return;
            }
            var newUser = new User
            {
                Id = rnd.Next(),
                FirstName = firstName,
                LastName = lastName,
                Login = login,
                Password = password,
                Email = email,
                Role = role
            };
            try
            {
                _authService.Register(newUser);
                MessageBox.Show("Registration successful. You can now log in.");
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorMessageTextBlock.Text = $"Registration failed: {ex.Message}";
            }
        }
    }
}
