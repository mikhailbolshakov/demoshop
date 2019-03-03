using DemoShop.Libs.Persistence.DbFactory;
using IdentityServer.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {

        private readonly DbFactory _dbFactory;

        public UserRepository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public bool ValidateCredentials(string username, string password)
        {
            var user = FindByUserName(username);
            if (user != null)
            {
                return user.Password.Equals(password);
            }

            return false;
        }

        public User FindBySubjectId(string subjectId)
        {

            using (var db = _dbFactory.CreateDatabase())
            {
                var userCol = db.GetCollection<UserBson>("user");
                var userBson = userCol.FindOne(x => x.UserId == Guid.Parse(subjectId));

                var user = new User()
                {
                    SubjectId = userBson.UserId.ToString(),
                    Email = userBson.Email,
                    UserName = userBson.UserName,
                    Password = userBson.Password
                };

                return user;
            }
        }

        public User FindByUserName(string userName)
        {

            using (var db = _dbFactory.CreateDatabase())
            {
                var userCol = db.GetCollection<UserBson>("user");
                var userBson = userCol.FindOne(x => x.UserName == userName);

                var user = new User()
                {
                    SubjectId = userBson.UserId.ToString(),
                    Email = userBson.Email,
                    UserName = userBson.UserName,
                    Password = userBson.Password
                };

                return user;
            }
        }
    }
}
