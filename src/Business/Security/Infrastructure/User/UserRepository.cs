using System;
using System.Collections.Generic;
using System.Text;
using DemoShop.Security.Domain.User;
using DemoShop.Security.Domain.User.Repository;
using DemoShop.Libs.Persistence.DbFactory;
using System.Linq;

namespace DemoShop.Security.Infrastructure.User
{
    public class UserRepository : IUserRepository
    {

        private readonly DbFactory _dbFactory;

        public UserRepository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public Domain.User.User Create(Domain.User.User user)
        {
            using (var db = _dbFactory.CreateDatabase())
            {
                var collection = db.GetCollection<UserPoco>("user");

                var id = Guid.NewGuid();

                var userPoco = new UserPoco
                {
                    Id = id,
                    UserName = "mike"
                };
                collection.Insert(userPoco);

                var result = collection.Find(x => x.Id == id).FirstOrDefault();

                if (result == null)
                    throw new Exception("Insert failed");

                return new Domain.User.User()
                {
                    UserId = result.Id,
                };
            }

        }
    }
}
