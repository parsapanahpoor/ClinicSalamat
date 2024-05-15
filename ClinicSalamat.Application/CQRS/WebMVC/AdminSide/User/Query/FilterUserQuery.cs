using ClinicSalamat.Application.Contract.DTOs.AdminSide.User;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.User.Query;

public class FilterUserQuery : IRequest<FilterUsersDTO>
{
    #region properties

    public FilterUsersDTO filter { get; set; }

    #endregion
}
