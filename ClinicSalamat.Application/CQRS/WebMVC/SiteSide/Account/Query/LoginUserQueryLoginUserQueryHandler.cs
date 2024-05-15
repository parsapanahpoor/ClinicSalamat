using ClinicSalamat.Application.Contract.DTOs.SiteSide.Account;
using ClinicSalamat.Application.Security;
using ClinicSalamat.Domain.IRepositories.User;

namespace ClinicSalamat.Application.CQRS.WebMVC.SiteSide.Account.Query;

public record LoginUserQueryLoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserResult>
{
    #region Ctor

    private readonly IUserQueryRepository _userQueryRepository;

    public LoginUserQueryLoginUserQueryHandler(IUserQueryRepository userQueryRepository)
    {
        _userQueryRepository = userQueryRepository;
    }

    #endregion

    public async Task<LoginUserResult> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        if (!await _userQueryRepository.IsMobileExist(request.Mobile.Trim().ToLower(), cancellationToken))
        {
            return LoginUserResult.MobileExist;
        }

        if (!await _userQueryRepository.IsUserActive(request.Mobile.Trim().ToLower(), cancellationToken))
        {
            return LoginUserResult.UserNotActive;
        }

        if (!await _userQueryRepository.IsPasswordValid(request.Mobile.Trim().ToLower(),
                  PasswordHelper.EncodePasswordMd5(request.Password), cancellationToken))
        {
            return LoginUserResult.WrongPassword;
        }

        return LoginUserResult.Success;
    }
}
