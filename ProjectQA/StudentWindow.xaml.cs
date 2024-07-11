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
    /// Логика взаимодействия для StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        private int currentQuestionIndex = 0;
        private Question currentQuestion;
        private List<Question> questions;
        private int userId;
        private int correctAnswersCount = 0;
        private string firstName;
        private string lastName;
        private string email;

        public StudentWindow(int userId, string firstName, string lastName, string email)
        {
            InitializeComponent();
            this.userId = userId;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.Title = $"Тест - {firstName} {lastName}";
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            using (var context = new DataContext())
            {
                questions = context.Questions.ToList();
                if (questions.Any())
                {
                    currentQuestion = questions[currentQuestionIndex];
                    DisplayQuestion();
                }
            }
        }

        private void DisplayQuestion()
        {
            if (currentQuestion != null)
            {
                QuestionsDataGrid.ItemsSource = new List<Question> { currentQuestion };
                AnswerTextBox.Clear();
            }
        }

        private void SubmitAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            var userAnswer = AnswerTextBox.Text.Trim();
            SaveUserAnswer(userAnswer);

            if (userAnswer.Equals(currentQuestion.CorrectAnswer, StringComparison.InvariantCultureIgnoreCase))
            {
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show($"Wrong! The correct answer is {currentQuestion.CorrectAnswer}");
            }
            currentQuestionIndex++;
            correctAnswersCount++;
            if (currentQuestionIndex < questions.Count)
            {
                currentQuestion = questions[currentQuestionIndex];
                DisplayQuestion();
            }
            else
            {
                ShowTestResult();
                this.Close();
            }
        }
        private void SaveUserAnswer(string answer)
        {
            using (var context = new DataContext())
            {
                var userAnswer = new UserAnswer
                {
                    UserId = userId,
                    QuestionId = currentQuestion.Id,
                    Answer = answer
                };

                context.UserAnswers.Add(userAnswer);
                context.SaveChanges();
            }
        }
        private void ShowTestResult()
        {
            int score = (correctAnswersCount * 12) / questions.Count;
            var resultWindow = new TestResultWindow(userId,firstName,lastName, email, score);
            resultWindow.Show();
        }
    }
}
