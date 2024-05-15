using ClinicSalamat.Application.Contract.DTOs.AdminSide.User;
using Microsoft.AspNetCore.Http;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.User.Command;

public class EditCurrentUserInfoCommand : IRequest<UserPanelEditUserInfoResult>
{
    #region properties

    public EditUserInfoDTO UserInfo { get; set; }

    public IFormFile? UserAvatar { get; set; }

    #endregion
}
