using ClinicSalamat.Application.Contract.DTOs.Common;
using ClinicSalamat.Application.Contract.IApplicationServices.Role;
using ClinicSalamat.Domain.IRepositories.Role;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.Role.Query;

internal class RoleSelectedListQueryHandler : IRequestHandler<RoleSelectedListQuery, List<SelectListViewModel>>
{
    #region Ctor

    private readonly IRoleQueryRepository _roleQueryRepository;
    private readonly IRoleApplicationService _roleApplicationService;

    public RoleSelectedListQueryHandler(IRoleQueryRepository roleQueryRepository, 
                                        IRoleApplicationService roleApplicationService)
    {
        _roleQueryRepository = roleQueryRepository;
        _roleApplicationService = roleApplicationService;
    }

    #endregion

    public async Task<List<SelectListViewModel>> Handle(RoleSelectedListQuery request, CancellationToken cancellationToken)
    {
        return await _roleApplicationService.GetSelectRolesList(cancellationToken);
    }
}
