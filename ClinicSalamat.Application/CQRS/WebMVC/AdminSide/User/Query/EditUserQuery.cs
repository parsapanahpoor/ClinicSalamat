using ClinicSalamat.Application.Contract.DTOs.AdminSide.User;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.User.Query;

public class EditUserQuery : IRequest<EditUserDTO>
{
    #region properties

    public ulong UserId { get; set; }

    #endregion
}
