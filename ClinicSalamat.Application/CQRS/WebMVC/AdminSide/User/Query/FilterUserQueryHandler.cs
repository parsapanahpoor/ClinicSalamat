using ClinicSalamat.Application.Contract.DTOs.AdminSide.User;
using ClinicSalamat.Application.Contract.IApplicationServices.User;
using ClinicSalamat.Domain.IRepositories.User;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.User.Query;

public record FilterUserQueryHandler : IRequestHandler<FilterUserQuery, FilterUsersDTO>
{
    #region Ctor

    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUserApplicationService _userApplicationService;

    public FilterUserQueryHandler(IUserQueryRepository userQueryRepository, 
                                  IUserApplicationService userApplicationService)
    {
        _userQueryRepository = userQueryRepository;
        _userApplicationService = userApplicationService;
    }

    #endregion

    public async Task<FilterUsersDTO> Handle(FilterUserQuery request, CancellationToken cancellationToken)
    {
        return await _userApplicationService.Filter_Users(request.filter , cancellationToken);
    }
}
