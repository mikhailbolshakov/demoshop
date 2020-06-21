using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Libs.DI
{
    /// <summary>
    /// should be implemented by Bootstrapper components
    /// </summary>
    public interface IDIComponent
    {
        /// <summary>
        /// configure dependencies
        /// </summary>
        void Bind(IServiceCollection services);

        /// <summary>
        /// does custom initialization after dependencies are bound
        /// </summary>
        void Initialize(IServiceProvider provider);
    }
}
