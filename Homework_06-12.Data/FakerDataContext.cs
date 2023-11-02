using Microsoft.EntityFrameworkCore;

namespace Homework_06_12.Data
{
    public class FakerDataContext : DbContext
    {
         private readonly string _connectionString;

        public FakerDataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Person> People { get; set; }

    }
}