#region properties

using ClinicSalamat.Infrastructure.EfCore.Validations.UsersAgg;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tls;
using System.Reflection;
namespace ClinicSalamat.Infrastructure.EfCore.ApplicationDbContext;

#endregion

public class ClinicSalamatDbContext : DbContext
{
    #region Ctor

    public ClinicSalamatDbContext(DbContextOptions<ClinicSalamatDbContext> options)
           : base(options)
    {

    }

    #endregion

    #region Entity

    #region Users Agg

    public DbSet<Domain.Entities.UsersAgg.User> Users { get; set; }

    #endregion

    #region Roles Agg

    public DbSet<Domain.Entities.RoleAgg.Permission> Permissions { get; set; }

    public DbSet<Domain.Entities.RoleAgg.Role> Roles { get; set; }

    public DbSet<Domain.Entities.RoleAgg.RolePermission> RolePermissions { get; set; }

    public DbSet<Domain.Entities.RoleAgg.UserRole> UserRoles { get; set; }

    #endregion

    #endregion

    #region OnConfiguring

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(UsersMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);
    }

    #endregion
}
