using ProjectQA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQA.Services
{
    public class AuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }

        public User Authenticate(string login, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Login == login && u.Password == password);
        }
        public bool UserExists(string login)
        {
            return _context.Users.Any(u => u.Login == login);
        }
        public void Register(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
