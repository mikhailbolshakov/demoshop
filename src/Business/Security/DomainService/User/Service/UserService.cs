using DemoShop.Security.Domain.User;
using DemoShop.Security.Domain.User.Repository;
using DemoShop.Security.Domain.User.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Security.DomainService.User.Service
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

        public Domain.User.User CreateUpdate(Domain.User.User user)
        {
            _repository.Create(null);
            return user;
        }

        public Domain.User.User GetById(Guid userId)
        {
            throw new NotImplementedException();
        }

        #endregion 
    }
}
