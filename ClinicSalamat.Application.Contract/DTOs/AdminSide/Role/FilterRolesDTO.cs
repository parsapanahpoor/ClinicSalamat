using ClinicSalamat.Application.Contract.DTOs.Common;

namespace ClinicSalamat.Application.Contract.DTOs.AdminSide.Role;

public class FilterRolesDTO : BasePaging<Domain.Entities.RoleAgg.Role>
{
    #region properties

    public string? RoleTitle { get; set; }

    #endregion
}
