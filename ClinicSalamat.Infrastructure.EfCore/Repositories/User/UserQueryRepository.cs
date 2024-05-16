using ClinicSalamat.Application.Contract.DTOs.AdminSide.User;
using ClinicSalamat.Application.Contract.IApplicationServices.User;
using ClinicSalamat.Domain.IRepositories.User;
using ClinicSalamat.Infrastructure.EfCore.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
namespace ClinicSalamat.Infrastructure.EfCore.Repositories.User;

public class UserQueryRepository : QueryGenericRepository<Domain.Entities.UsersAgg.User>, IUserQueryRepository , IUserApplicationService
{
    #region Ctor

    private readonly ClinicSalamatDbContext _context;

    public UserQueryRepository(ClinicSalamatDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region General Methods

    public async Task<bool> IsMobileExist(string mobile, CancellationToken cancellation)
    {
        return await _context.Users
                             .AsNoTracking()
                             .AnyAsync(p => !p.IsDelete &&
                                       p.Mobile == mobile);
    }

    public async Task<bool> IsUserActive(string mobile, CancellationToken cancellation)
    {
        return await _context.Users
                             .AsNoTracking()
                             .AnyAsync(p => !p.IsDelete &&
                                       p.Mobile == mobile &&
                                       p.IsActive);
    }

    public async Task<bool> IsPasswordValid(string mobile, string password, CancellationToken cancellation)
    {
        return await _context.Users
                             .AsNoTracking()
                             .AnyAsync(p => !p.IsDelete &&
                                       p.Mobile == mobile &&
                                       p.Password == password);
    }

    public async Task<Domain.Entities.UsersAgg.User?> GetUserByMobile(string mobile, CancellationToken cancellation)
    {
        return await _context.Users
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete &&
                                                  p.Mobile == mobile);
    }

    #endregion

    #region Site Side

    public async Task<bool> IsValidNationalIdForUserEditByAdmin(string nationalId, ulong userId, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(s => !s.IsDelete && s.NationalId == nationalId.Trim());

        if (user == null) return true;
        if (user.Id == userId) return true;

        return false;
    }

    public async Task<FilterUsersDTO> Filter_Users(FilterUsersDTO filter, 
                                                   CancellationToken cancellation)
    {
        var query = _context.Users
                           .AsNoTracking()
                           .OrderByDescending(p => p.CreateDate)
                           .AsQueryable();

        #region filter

        if ((!string.IsNullOrEmpty(filter.Mobile)))
        {
            query = query.Where(u => u.Mobile.Contains(filter.Mobile));
        }

        if ((!string.IsNullOrEmpty(filter.Username)))
        {
            query = query.Where(u => u.Username.Contains(filter.Username));
        }

        #endregion

        #region paging

        await filter.Paging(query);

        #endregion

        return filter;
    }

    #endregion
}
