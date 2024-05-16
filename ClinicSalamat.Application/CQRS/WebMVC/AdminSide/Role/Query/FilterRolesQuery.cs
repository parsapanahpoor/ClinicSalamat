using ClinicSalamat.Application.Contract.DTOs.AdminSide.Role;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.Role.Query;

public class FilterRolesQuery : IRequest<FilterRolesDTO>
{
    #region properties

    public FilterRolesDTO Filter { get; set; }

    #endregion
}
