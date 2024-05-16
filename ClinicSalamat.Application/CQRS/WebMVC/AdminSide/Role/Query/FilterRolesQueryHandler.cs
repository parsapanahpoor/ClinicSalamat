using ClinicSalamat.Application.Contract.DTOs.AdminSide.Role;
using ClinicSalamat.Application.Contract.IApplicationServices.Role;
using ClinicSalamat.Domain.IRepositories.Role;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.Role.Query;

public record FilterRolesQueryHandler : IRequestHandler<FilterRolesQuery, FilterRolesDTO>
{
    #region Ctor

    private readonly IRoleQueryRepository _roleQueryRepository;
    private readonly IRoleApplicationService _roleApplicationService;

    public FilterRolesQueryHandler(IRoleQueryRepository roleQueryRepository, 
                                   IRoleApplicationService roleApplicationService)
    {
        _roleQueryRepository = roleQueryRepository;
        _roleApplicationService = roleApplicationService;
    }

    #endregion

    public async Task<FilterRolesDTO?> Handle(FilterRolesQuery request, CancellationToken cancellationToken)
    {
        return await _roleApplicationService.Filter_Roles(request.Filter , cancellationToken);
    }
}
