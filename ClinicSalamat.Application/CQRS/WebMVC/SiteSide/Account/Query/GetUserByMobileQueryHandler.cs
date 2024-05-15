using ClinicSalamat.Domain.IRepositories.User;

namespace ClinicSalamat.Application.CQRS.WebMVC.SiteSide.Account.Query;

public record GetUserByMobileQueryHandler : IRequestHandler<GetUserByMobileQuery, Domain.Entities.UsersAgg.User>
{
    #region Ctor

    private readonly IUserQueryRepository _userQueryRepository;

    public GetUserByMobileQueryHandler(IUserQueryRepository userQueryRepository)
    {
        _userQueryRepository = userQueryRepository;
    }

    #endregion

    public async Task<Domain.Entities.UsersAgg.User?> Handle(GetUserByMobileQuery request, CancellationToken cancellationToken)
    {
        return await _userQueryRepository.GetUserByMobile(request.Mobile.Trim().ToLower(), cancellationToken);
    }
}
