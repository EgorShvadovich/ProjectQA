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
    /// Логика взаимодействия для TestResultWindow.xaml
    /// </summary>
    public partial class TestResultWindow : Window
    {
        private EmailService emailService;
        private int userId;
        private string email;
        private int score;
        private string firstName;
        private string lastName;

        public TestResultWindow(int userId,string firstName,string lastName, string email, int score)
        {
            InitializeComponent();
            this.userId = userId;
            this.email = email;
            this.score = score;
            this.firstName = firstName;
            this.lastName = lastName;
            ResultTextBlock.Text = $"Ваш результат: {score}/12б";
            emailService = new EmailService();
        }
        private void SendResultButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SendEmailResult();
                MessageBox.Show("Результат успешно отправлен на почту.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке почты: {ex.Message}");
            }
        }

        private void SendEmailResult()
        {
            string subject = "Результаты теста";
            string body = $"Уважаемый(ая) {firstName} {lastName},\n\nВаш результат: {score}/12б.";

            emailService.SendEmail(email, subject, body);
        }
        private void RetakeTestButton_Click(object sender, RoutedEventArgs e)
        {
            var studentWindow = new StudentWindow(userId, firstName,lastName, email);
            studentWindow.Show();
            this.Close();
        }

        private void ExitToMainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

