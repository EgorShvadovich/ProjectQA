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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectQA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AuthService _authService;

        public MainWindow()
        {
            InitializeComponent();
            _authService = new AuthService(new DataContext());
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var user = _authService.Authenticate(LoginTextBox.Text, PasswordBox.Password);

            if (user != null)
            {
                if (user.Role == "Admin")
                {
                    var adminWindow = new AdminWindow();
                    adminWindow.Show();
                }
                else if (user.Role == "Student")
                {
                    var studentWindow = new StudentWindow(user.Id, user.FirstName, user.LastName, user.Email);
                    studentWindow.Show();
                    this.Close();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid login or password");
            }
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog(); 
        }

    }
}
