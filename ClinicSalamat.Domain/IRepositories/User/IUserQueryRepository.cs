using ClinicSalamat.Domain.Entities.UsersAgg;

namespace ClinicSalamat.Domain.IRepositories.User;

public interface IUserQueryRepository
{
    #region General Methods

    Task<bool> IsMobileExist(string mobile, CancellationToken cancellation);

    Task<bool> IsUserActive(string mobile , CancellationToken cancellation);

    Task<bool> IsPasswordValid(string mobile, string password, CancellationToken cancellation);

    Task<Entities.UsersAgg.User?> GetUserByMobile(string mobile, CancellationToken cancellation);

    Task<Entities.UsersAgg.User> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);

    #endregion

    #region Site Side

    Task<bool> IsValidNationalIdForUserEditByAdmin(string nationalId, ulong userId, CancellationToken cancellationToken);

    #endregion
}
