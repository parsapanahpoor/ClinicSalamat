using ClinicSalamat.Domain.Entities.UsersAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicSalamat.Infrastructure.EfCore.Validations.UsersAgg;

public class UsersMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(t => t.Id);
        builder.Property(p => p.Username).HasMaxLength(50);   
        builder.Property(p => p.FirstName).HasMaxLength(50);   
        builder.Property(p => p.LastName).HasMaxLength(50);   
        builder.Property(p => p.NationalId).HasMaxLength(50);   
        builder.Property(p => p.Mobile).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Password).IsRequired();
        builder.Property(p => p.ExpireMobileSMSDateTime);
        builder.Property(p => p.IsDelete);   
        builder.Property(p => p.IsAdmin);   
        builder.Property(p => p.IsActive);   
        builder.Property(p => p.Avatar);   
        builder.Property(p => p.UpdateDate);   
        builder.Property(p => p.CreateDate);   
    }
}
