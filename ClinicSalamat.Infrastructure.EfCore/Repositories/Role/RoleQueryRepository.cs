using ClinicSalamat.Domain.IRepositories.Role;
using Microsoft.EntityFrameworkCore;

namespace ClinicSalamat.Infrastructure.EfCore.Repositories.Role;

public class RoleQueryRepository : QueryGenericRepository<Domain.Entities.RoleAgg.Role>, IRoleQueryRepository
{
    #region Ctor

    private readonly ClinicSalamatDbContext _context;

    public RoleQueryRepository(ClinicSalamatDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region Site Side 

    public async Task<bool> HasUserPermission(ulong userId, string permissionName)
    {
        // get user
        var user = await _context.Users
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(s => s.Id == userId && !s.IsDelete);

        // check user exists
        if (user == null) return false;

        // admin user access any where
        if (user.IsAdmin) return true;

        // get permission from permission list
        var permission = Application.Contract.StaticTools.PermissionsList.Permissions.FirstOrDefault(s => s.PermissionUniqueName == permissionName);

        // check permission exists
        if (permission == null) return false;

        // get user roles
        var userRoles = await _context.UserRoles
                                      .AsNoTracking()
                                      .Where(s => s.UserId == userId && 
                                             !s.IsDelete)
                                       .ToListAsync();

        // check user has any roles
        if (!userRoles.Any()) return false;

        // get user role Ids list
        var userRoleIds = userRoles.Select(s => s.RoleId).ToList();

        // check user has permission
        var result = await _context.RolePermissions.AnyAsync(s =>
            s.PermissionId == permission.Id && userRoleIds.Contains(s.RoleId) && !s.IsDelete);

        return result;
    }

    public async Task<List<ulong>> GetUserSelectedRoleIdByUserId(ulong userId,
                                                                 CancellationToken cancellation)
    {
        return await _context.UserRoles
                             .AsNoTracking()
                             .Where(s => !s.IsDelete &&
                                    s.UserId == userId)
                             .Select(s => s.RoleId)
                             .ToListAsync();
    }

    public async Task<bool> IsExistAnyRoleByRoleUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.Roles
                             .AsNoTracking()
                             .AnyAsync(p => !p.IsDelete &&
                                       p.Title == title);
    }

    public async Task<Domain.Entities.RoleAgg.Role?> GetRoleByUniqueTitle(string title, CancellationToken cancellation)
    {
        return await _context.Roles
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete &&
                                                  p.RoleUniqueName == title);
    }

    public async Task<List<ulong>> GetRolePermissionsIdByRoleId(ulong roleId, CancellationToken cancellationToken)
    {
        return await _context.RolePermissions
                             .AsNoTracking()
                             .Where(p => !p.IsDelete &&
                                    p.RoleId == roleId)
                             .Select(p => p.PermissionId)
                             .ToListAsync();
    }

    #endregion
}
