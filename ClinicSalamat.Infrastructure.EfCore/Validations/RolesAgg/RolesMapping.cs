using ClinicSalamat.Domain.Entities.RoleAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicSalamat.Infrastructure.EfCore.Validations.RolesAgg;

public class RolesMapping : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.RoleUniqueName).IsRequired().HasMaxLength(100);
        builder.Property(t => t.Title).IsRequired().HasMaxLength(100);
        builder.Property(t => t.IsDelete);
        builder.Property(t => t.CreateDate);
        builder.Property(t => t.UpdateDate);
    }
}
