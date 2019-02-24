using IdentityServer.Repository.Contract;
using IdentityServer.Repository.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public static class IdentityServerBuilderCustomExtension
    {
        public static IIdentityServerBuilder AddCustomUserStore(this IIdentityServerBuilder builder)
        {
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.AddProfileService<CustomProfileService>();
            builder.AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>();

            return builder;
        }

    }

}
