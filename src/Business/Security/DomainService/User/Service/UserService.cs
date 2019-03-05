using DemoShop.Libs.WebApi.ExceptionHandling.CustomExceptions;
using DemoShop.Security.Domain.User;
using DemoShop.Security.Domain.User.Consts;
using DemoShop.Security.Domain.User.Repository;
using DemoShop.Security.Domain.User.Service;
using System;
using System.Collections.Generic;
using System.Linq;
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

        #region private method

        private User EnrichNewUser(User user)
        {
            // setup an Id
            user.UserId = Guid.NewGuid();

            // set customer role by default
            // for additional roles GrantRoles method has to be called explicitly
            user.Roles = new List<string> { RolesConsts.CUSTOMER };

            return user;
        }

        private void ValidateRoles(List<string> roles)
        {
            roles.ForEach(r =>
                {
                    if (!RolesConsts.IsValid(r))
                        throw new DsValidationException($"Role {r} isn't a valid role name");
                }
            );

        }

        private void ValidateNewUser(User user)
        {
            // check uniqueness of email/username
        }

        #endregion 

        #region IUserService

        public async Task<User> RegisterUserAsync(User user)
        {
            // enrich a new user with default values
            var userInternal = EnrichNewUser(user);

            // validate
            ValidateNewUser(user);

            // persist
            await _repository.CreateAsync(userInternal);

            // TODO: Domain event

            return userInternal;
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            var user =
                await _repository.GetByIdAsync(userId)
                ?? throw new DsNotFoundException($"User isn't found by id: {userId}");

            return user;
        }

        public async Task<User> Grant(Guid userId, List<string> roles)
        {
            var user = await GetByIdAsync(userId);

            if (roles != null && roles.Any())
            {
                // validate roles
                ValidateRoles(roles);

                // identify which roles need to be granted
                var rolesToGrant = roles.Except(user.Roles ?? Enumerable.Empty<string>());

                if (rolesToGrant.Any())
                {

                    // grant roles & update user
                    user.Roles.AddRange(rolesToGrant);

                    await _repository.UpdateAsync(user);

                    // TODO: domain event

                }
            }

            return user;
        }

        public async Task<User> Revoke(Guid userId, List<string> roles)
        {
            var user = await GetByIdAsync(userId);

            if (user.Roles != null && user.Roles.Any())
            {
                // validate roles
                ValidateRoles(roles);

                // populate a new roles without revoked ones
                var revokedRoles = user.Roles.Except(roles ?? Enumerable.Empty<string>());
                user.Roles = revokedRoles.ToList();

                // update user
                await _repository.UpdateAsync(user);

                // TODO: domain event

            }

            return user;
        }

        #endregion
    }
}
