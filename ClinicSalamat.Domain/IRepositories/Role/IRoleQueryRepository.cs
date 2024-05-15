namespace ClinicSalamat.Domain.IRepositories.Role;

public interface IRoleQueryRepository
{
    #region Site Side 

    Task<bool> HasUserPermission(ulong userId, string permissionName);

    Task<List<ulong>> GetUserSelectedRoleIdByUserId(ulong userId,
                                                    CancellationToken cancellation);

    Task<Domain.Entities.RoleAgg.Role> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);

    Task<bool> IsExistAnyRoleByRoleUniqueTitle(string title, CancellationToken cancellationToken);

    Task<Domain.Entities.RoleAgg.Role?> GetRoleByUniqueTitle(string title, CancellationToken cancellation);

    Task<List<ulong>> GetRolePermissionsIdByRoleId(ulong roleId, CancellationToken cancellationToken);

    #endregion
}
