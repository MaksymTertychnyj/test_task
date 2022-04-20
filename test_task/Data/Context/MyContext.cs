using Microsoft.EntityFrameworkCore;
using test_task.Data.Entities;
using test_task.Data.EntityConfigurations;

namespace test_task.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Incident> Incidents { get; set; }

        public MyContext(DbContextOptions<MyContext> optionsBuilder)
            : base(optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new ContactConfiguration());
            builder.ApplyConfiguration(new IncidentConfiguration());
        }
    }
}
