using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Homework_06_12.Data
{
    public class FakerContextFactory : IDesignTimeDbContextFactory<FakerDataContext>
    {
        public FakerDataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}Homework_06-12.Web"))
              .AddJsonFile("appsettings.json")
              .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new FakerDataContext(config.GetConnectionString("ConStr"));
        }
    }
}