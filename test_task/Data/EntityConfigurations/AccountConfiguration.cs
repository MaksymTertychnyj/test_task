using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using test_task.Data.Entities;

namespace test_task.Data.EntityConfigurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts");
            builder.HasKey(account => account.Name);
            builder.HasIndex(account => account.Name).IsUnique(true);
            builder.HasOne(account => account.Incident).WithMany(incident => incident.Accounts)
                .HasForeignKey(account => account.IncidentName);
        }
    }
}
