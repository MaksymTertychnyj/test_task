using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using test_task.Data.Entities;

namespace test_task.Data.EntityConfigurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("contacts");
            builder.HasKey(contact => contact.Email);
            builder.HasIndex(contact => contact.Email).IsUnique(true);
            builder.HasOne(contact => contact.Account).WithMany(account => account.Contacts)
                .HasForeignKey(contact => contact.AccountName);
        }
    }
}
