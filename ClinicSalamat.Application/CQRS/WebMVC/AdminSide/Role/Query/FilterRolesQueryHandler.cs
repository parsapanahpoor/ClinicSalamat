using ClinicSalamat.Application.Contract.DTOs.AdminSide.Role;
using ClinicSalamat.Domain.IRepositories.Role;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.Role.Query;

public record FilterRolesQueryHandler : IRequestHandler<FilterRolesQuery, FilterRolesDTO>
{
    #region Ctor

    private readonly IRoleQueryRepository _roleQueryRepository;

    public FilterRolesQueryHandler(IRoleQueryRepository roleQueryRepository)
    {
        _roleQueryRepository = roleQueryRepository;
    }

    #endregion

    public async Task<FilterRolesDTO?> Handle(FilterRolesQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
