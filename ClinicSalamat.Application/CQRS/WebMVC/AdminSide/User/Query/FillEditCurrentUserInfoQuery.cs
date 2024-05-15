using ClinicSalamat.Application.Contract.DTOs.AdminSide.User;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.User.Query;

public class FillEditCurrentUserInfoQuery : IRequest<EditUserInfoDTO>
{
    public ulong userId { get; set; }
}
