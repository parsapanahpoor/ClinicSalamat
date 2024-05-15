using ClinicSalamat.Domain.Entities.RoleAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicSalamat.Infrastructure.EfCore.Validations.RolesAgg;

public class PermissionsMapping : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permissions");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.PermissionUniqueName).IsRequired().HasMaxLength(100);
        builder.Property(t => t.Title).IsRequired().HasMaxLength(100);
        builder.Property(t => t.IsDelete);
        builder.Property(t => t.CreateDate);
        builder.Property(t => t.UpdateDate);
    }
}
