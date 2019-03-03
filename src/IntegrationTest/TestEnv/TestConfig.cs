using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.IntegrationTest.TestEnv
{
    public static class TestConfig
    {

        static TestConfig()
        {
            _configuration = new Lazy<IConfiguration>(() =>
            { 
                var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
                return config;
            });
        }

        private static Lazy<IConfiguration> _configuration;

        public static IConfiguration Configuration { get
            {
                return _configuration.Value;
            }
        }

    }
}
