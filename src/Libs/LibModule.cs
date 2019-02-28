using AutoMapper;
using AutoMapper.Configuration;
using DemoShop.Libs.AutoMapper;
using DemoShop.Libs.DI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoShop.Libs
{
    public class LibModule : DIModuleBase
    {

        private void InitializeMappers(IServiceProvider provider)
        {
            var cfg = new MapperConfigurationExpression();
            provider.GetServices<IAutoMapperInitializer>().ToList().ForEach(a => a.Initialize(cfg));
            Mapper.Initialize(cfg);
        }

        public override void Initialize(IServiceProvider provider)
        {
            InitializeMappers(provider);
            base.Initialize(provider);
        }

        protected override IEnumerable<IDIComponent> Components()
        {
            return new IDIComponent[]
                    {
                        new LibPersistenceComponent()
                    };
        }

    }
}
