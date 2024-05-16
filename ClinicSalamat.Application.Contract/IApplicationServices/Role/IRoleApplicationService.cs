using ClinicSalamat.Application.Contract.DTOs.AdminSide.Role;
using ClinicSalamat.Application.Contract.DTOs.Common;

namespace ClinicSalamat.Application.Contract.IApplicationServices.Role;

public interface IRoleApplicationService 
{
	#region Admin Side Requirements

	Task<FilterRolesDTO> Filter_Roles(FilterRolesDTO filter , CancellationToken cancellation);

    Task<List<SelectListViewModel>> GetSelectRolesList(CancellationToken cancellation);

    #endregion
}
