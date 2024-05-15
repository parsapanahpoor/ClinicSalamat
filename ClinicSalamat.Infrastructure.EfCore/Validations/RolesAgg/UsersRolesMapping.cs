using ClinicSalamat.Domain.Entities.RoleAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicSalamat.Infrastructure.EfCore.Validations.RolesAgg;

public class UsersRolesMapping : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UsersRoles");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.IsDelete);
        builder.Property(t => t.RoleId);
        builder.Property(t => t.UserId);
        builder.Property(t => t.CreateDate);
        builder.Property(t => t.UpdateDate);
    }
}
