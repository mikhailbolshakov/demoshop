using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace DemoShop.Libs.DI
{
    public abstract class DIComponentBase : IDIComponent
    {
        public void Bind(IServiceCollection services)
        {
            BindCustom(services);
        }

        public void Initialize(IServiceProvider provider)
        {
            InitializeCustom(provider);
        }

        protected abstract void BindCustom(IServiceCollection services);
        protected abstract void InitializeCustom(IServiceProvider provider);
    }
}
