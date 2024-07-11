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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private AdminService _adminService;

        public AdminWindow()
        {
            InitializeComponent();
            _adminService = new AdminService(new DataContext());
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            QuestionsListBox.ItemsSource = _adminService.GetQuestions();
            QuestionsListBox.DisplayMemberPath = "Text";
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            _adminService.AddQuestion(QuestionTextBox.Text, CorrectAnswerTextBox.Text);
            LoadQuestions();
        }

        private void EditQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionsListBox.SelectedItem is Question selectedQuestion)
            {
                _adminService.EditQuestion(selectedQuestion.Id, QuestionTextBox.Text, CorrectAnswerTextBox.Text);
                LoadQuestions();
            }
        }

        private void DeleteQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionsListBox.SelectedItem is Question selectedQuestion)
            {
                _adminService.DeleteQuestion(selectedQuestion.Id);
                LoadQuestions();
            }
        }
        private void QuestionsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (QuestionsListBox.SelectedItem is Question selectedQuestion)
            {
                QuestionTextBox.Text = selectedQuestion.Text;
                CorrectAnswerTextBox.Text = selectedQuestion.CorrectAnswer;
            }
        }
    }
}
