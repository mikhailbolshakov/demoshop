using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace DemoShop.Libs.DI
{
    public abstract class DIModuleBase : IDIModule
    {
        protected abstract IEnumerable<IDIComponent> Components();

        public void Bind(IServiceCollection services)
        {
            Components().ToList().ForEach(a => a.Bind(services));
        }

        public void Initialize(IServiceProvider provider)
        {
            Components().ToList().ForEach(a => a.Initialize(provider));
        }
    }
}
