using System;
using System.Collections.Generic;
using System.Text;
using DemoShop.Security.Domain.User;
using DemoShop.Security.Domain.User.Repository;
using DemoShop.Libs.Persistence.DbFactory;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace DemoShop.Security.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {

        private readonly DbFactory _dbFactory;

        public UserRepository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<User> Create(User user)
        {
            using (var db = _dbFactory.CreateDatabase())
            {

                var bson = UserRepositoryMapper.Map(user);

                var userCollection = db.GetCollection<UserBson>("user");

                await Task.Run(() => userCollection.Insert(bson));
                await Task.Run(() => userCollection.EnsureIndex(x => x.Email));

                return UserRepositoryMapper.Map(bson);

            }

        }

    }
}
