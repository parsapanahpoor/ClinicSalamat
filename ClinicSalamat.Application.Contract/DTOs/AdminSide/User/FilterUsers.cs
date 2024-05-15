using ClinicSalamat.Application.Contract.DTOs.Common;

namespace ClinicSalamat.Application.Contract.DTOs.AdminSide.User;

public class FilterUsersDTO : BasePaging<Domain.Entities.UsersAgg.User>
{
    #region properties

    public string? Username { get; set; }

    public string? Mobile { get; set; }

    #endregion
}
