using ClinicSalamat.Application.Contract.DTOs.Common;
using ClinicSalamat.Domain.IRepositories.Role;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.Role.Query;

internal class RoleSelectedListQueryHandler : IRequestHandler<RoleSelectedListQuery, List<SelectListViewModel>>
{
    #region Ctor

    private readonly IRoleQueryRepository _roleQueryRepository;

    public RoleSelectedListQueryHandler(IRoleQueryRepository roleQueryRepository)
    {
        _roleQueryRepository = roleQueryRepository;
    }

    #endregion

    public async Task<List<SelectListViewModel>> Handle(RoleSelectedListQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
