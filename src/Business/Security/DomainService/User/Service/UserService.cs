using DemoShop.Libs.WebApi.ExceptionHandling.CustomExceptions;
using DemoShop.Security.Domain.User;
using DemoShop.Security.Domain.User.Repository;
using DemoShop.Security.Domain.User.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Security.DomainService.Users.Service
{
    public class UserService : IUserService
    {

        #region private fields

        private readonly IUserRepository _repository;

        #endregion 

        #region ctor

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        #endregion 

        #region IUserService

        public async Task<User> RegisterUserAsync(User user)
        {
            user.UserId = user.UserId ?? Guid.NewGuid();

            var modifiedObj = await _repository.CreateAsync(user);

            return user;
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            var user =
                await _repository.GetByIdAsync(userId)
                ?? throw new DsNotFoundException($"User isn't found by id: {userId}");

            return user;
        }

        #endregion 
    }
}
