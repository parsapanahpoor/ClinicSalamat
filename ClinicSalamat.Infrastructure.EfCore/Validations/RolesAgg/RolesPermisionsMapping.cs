using ClinicSalamat.Domain.Entities.RoleAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicSalamat.Infrastructure.EfCore.Validations.RolesAgg;

public class RolesPermissionMapping : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("RolesPermissions");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.IsDelete);
        builder.Property(t => t.RoleId);
        builder.Property(t => t.PermissionId);
        builder.Property(t => t.CreateDate);
        builder.Property(t => t.UpdateDate);
    }
}
