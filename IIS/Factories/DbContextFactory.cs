using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IIS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IIS.Factories
{
    public class DbContextFactory : IDbContextFactory
    {
        public FifkaDBContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FifkaDBContext>();

            optionsBuilder.UseSqlServer(
                @"Data Source=fifkadb.database.windows.net;
                Initial Catalog=FifkaDB;
                User ID=xabrah04;Password=Fitterdb1;
                Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            return new FifkaDBContext(optionsBuilder.Options, config);
        }
    }
}
