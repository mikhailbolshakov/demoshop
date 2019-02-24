using IdentityServer.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly List<CustomUser> _users = new List<CustomUser>
        {
            new CustomUser{
                SubjectId = "1",
                UserName = "mike",
                Password = "mike",
                Email = "mike@gmail.com"
            },
            new CustomUser{
                SubjectId = "2",
                UserName = "raphael",
                Password = "raphael",
                Email = "raphael@email.ch"
            },
        };

        public bool ValidateCredentials(string username, string password)
        {
            var user = FindByUsername(username);
            if (user != null)
            {
                return user.Password.Equals(password);
            }

            return false;
        }

        public CustomUser FindBySubjectId(string subjectId)
        {
            return _users.FirstOrDefault(x => x.SubjectId == subjectId);
        }

        public CustomUser FindByUsername(string username)
        {
            return _users.FirstOrDefault(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
