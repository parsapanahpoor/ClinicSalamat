using ClinicSalamat.Application.Contract.DTOs.AdminSide.User;
using ClinicSalamat.Domain.IRepositories.User;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.User.Query;

public record FilterUserQueryHandler : IRequestHandler<FilterUserQuery, FilterUsersDTO>
{
    #region Ctor

    private readonly IUserQueryRepository _userQueryRepository;

    public FilterUserQueryHandler(IUserQueryRepository userQueryRepository)
    {
        _userQueryRepository = userQueryRepository;
    }

    #endregion

    public async Task<FilterUsersDTO> Handle(FilterUserQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
