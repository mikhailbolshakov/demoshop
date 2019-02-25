using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using LiteDB;

namespace DemoShop.Libs.Persistence.DbFactory
{
    public class DbFactory //: IDbFactory
    {

        private readonly string _connectionString;

        public DbFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public LiteDatabase CreateDatabase()
        {
            return new LiteDatabase(_connectionString);
        }


    }
}
