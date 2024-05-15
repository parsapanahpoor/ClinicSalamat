namespace ClinicSalamat.Domain.IRepositories.Role;

public interface IRoleCommandRepository
{
    #region Site Side

    Task RemoveUserRolesByUserId(ulong userId, CancellationToken cancellationToken);

    Task AddUserSelectedRole(ClinicSalamat.Domain.Entities.RoleAgg.UserRole userRole, CancellationToken cancellationToken);

    Task AddAsync(ClinicSalamat.Domain.Entities.RoleAgg.Role role, CancellationToken cancellationToken);

    void Update(ClinicSalamat.Domain.Entities.RoleAgg.Role role);

    Task AddPermissionToRole(ClinicSalamat.Domain.Entities.RoleAgg.RolePermission rolePermission);

    Task RemoveRolePermissions(ulong roleId, List<ulong> rolePermissions, CancellationToken cancellation);

    #endregion
}
