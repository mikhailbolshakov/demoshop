using System;
using System.Collections.Generic;
using System.Text;
using DemoShop.Security.Domain.User;
using DemoShop.Security.Domain.User.Repository;
using DemoShop.Libs.Persistence.DbFactory;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using DemoShop.Security.Infrastructure.Consts;

namespace DemoShop.Security.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {

        #region private fields

        private readonly DbFactory _dbFactory;

        #endregion

        #region ctor

        public UserRepository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        #endregion

        #region IUserRepository

        public async Task<User> CreateAsync(User user)
        {
            using (var db = _dbFactory.CreateDatabase())
            {

                var bson = UserRepositoryMapper.Map(user);

                var userCol = db.GetCollection<UserBson>(DBCollectionConsts.USER);

                await Task.Run(() => userCol.Insert(bson));
                await Task.Run(() => userCol.EnsureIndex(x => x.Email));
                await Task.Run(() => userCol.EnsureIndex(x => x.UserName));

                return UserRepositoryMapper.Map(bson);

            }

        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            using (var db = _dbFactory.CreateDatabase())
            {

                var userCol = db.GetCollection<UserBson>(DBCollectionConsts.USER);

                var bson = await Task.Run(() => userCol.FindById(new BsonValue(userId)));

                return UserRepositoryMapper.Map(bson);
            }
        }

        public async Task<User> UpdateAsync(User user)
        {

            using (var db = _dbFactory.CreateDatabase())
            {

                var bson = UserRepositoryMapper.Map(user);

                var userCol = db.GetCollection<UserBson>(DBCollectionConsts.USER);

                await Task.Run(() => userCol.Update(bson));

                return UserRepositoryMapper.Map(bson);

            }
        }

        #endregion
    }
}
