using ProjectQA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQA.Services
{
    public class AdminService
    {
        private readonly DataContext _context;

        public AdminService(DataContext context)
        {
            _context = context;
        }

        public void AddQuestion(string text, string correctAnswer)
        {
            var question = new Question
            {
                Text = text,
                CorrectAnswer = correctAnswer
            };
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        public void EditQuestion(int id, string text, string correctAnswer)
        {
            var question = _context.Questions.Find(id);
            if (question != null)
            {
                question.Text = text;
                question.CorrectAnswer = correctAnswer;
                _context.SaveChanges();
            }
        }
        public List<Question> GetQuestions()
        {
            return _context.Questions.ToList();
        }

        public void DeleteQuestion(int id)
        {
            var question = _context.Questions.Find(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
        }
    }
}
