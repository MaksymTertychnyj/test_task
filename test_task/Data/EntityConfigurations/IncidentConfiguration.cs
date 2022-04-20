using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using test_task.Data.Entities;

namespace test_task.Data.EntityConfigurations
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.ToTable("incidents");
            builder.HasKey(incident => incident.Name);
        }
    }
}
