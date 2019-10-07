using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Data
{
    public class FifkaDBContextFactory : IDesignTimeDbContextFactory<FifkaDBContext>
    {
        public FifkaDBContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            return new FifkaDBContext(new DbContextOptionsBuilder<FifkaDBContext>().Options, config);
        }       
    }
}
