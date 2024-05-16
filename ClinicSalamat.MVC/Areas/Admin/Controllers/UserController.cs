using ClinicSalamat.Application.Contract.DTOs.AdminSide.User;
using ClinicSalamat.Application.CQRS.WebMVC.AdminSide.Role.Query;
using ClinicSalamat.Application.CQRS.WebMVC.AdminSide.User.Command;
using ClinicSalamat.Application.CQRS.WebMVC.AdminSide.User.Query;
using ClinicSalamat.Application.Security;
using ClinicSalamat.Presentation.HttpManager;
using ClinicSalamat.Application.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ClinicSalamat.Presentation.Areas.Admin.Controllers;

[PermissionChecker("ManageAccount")]
public class UserController : AdminBaseController
{
    #region Filter Users

    [PermissionChecker("UsersList")]
    public async Task<IActionResult> FilterUsers(FilterUsersDTO model,
                                                 CancellationToken cancellationToken = default)
    {
        FilterUserQuery query = new FilterUserQuery()
        {
            filter = model
        };

        return View(await Mediator.Send(query, cancellationToken));
    }

    #endregion

    #region Edit User

    [PermissionChecker("EditUserInfo")]
    [HttpGet]
    public async Task<IActionResult> EditUser(EditUserQuery userQuery,
                                              CancellationToken cancellation = default)
    {
        var user = await Mediator.Send(userQuery, cancellation);
        if (user == null) return RedirectToAction(nameof(FilterUsers));

        #region Page Data

        ViewData["Roles"] = await Mediator.Send(new RoleSelectedListQuery(), cancellation);

        #endregion

        return View(user);
    }

    [PermissionChecker("EditUserInfo")]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUser(EditUserDTO userDTO,
                                              IFormFile UserAvatar,
                                              CancellationToken cancellation = default)
    {
        #region Page Data

        ViewData["Roles"] = await Mediator.Send(new RoleSelectedListQuery(), cancellation);

        #endregion

        var res = await Mediator.Send(new EdirUserCommand()
        {
            avatar = UserAvatar,
            Avatar = userDTO.Avatar,
            Id = userDTO.Id,
            IsActive = userDTO.IsActive,
            Mobile = userDTO.Mobile,
            Password = userDTO.Password,
            Username = userDTO.Username,
            UserRoles = userDTO.UserRoles
        },
        cancellation);

        switch (res)
        {
            case EditUserResult.DuplicateEmail:
                TempData[ErrorMessage] = "ایمیل وارد شده صحیح نمی باشد .";
                break;

            case EditUserResult.DuplicateMobileNumber:
                TempData[ErrorMessage] = "موبایل وارد شده تکراری می باشد.";
                break;

            case EditUserResult.Success:
                return RedirectToAction(nameof(FilterUsers));
        }

        return View();
    }

    #endregion

    #region Delete User 

    public async Task<IActionResult> DeleteUser(DeleteUserCommand command,
                                                CancellationToken token = default)
    {
        var result = await Mediator.Send(command, token);
        if (result) return JsonResponseStatus.Success();

        return JsonResponseStatus.Error();
    }

    #endregion

    #region Edit Current User Info 

    #region Edit Current UserInfo

    [HttpGet]
    public async Task<IActionResult> EditCurrentUserInfo(CancellationToken cancellationToken = default)
    {
        var res = await Mediator.Send(new FillEditCurrentUserInfoQuery()
        {
            userId = User.GetUserId(),
        },
        cancellationToken);

        if (res == null) return NotFound();

        return View(res);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditCurrentUserInfo(EditUserInfoDTO edit,
                                                         IFormFile? UserAvatar,
                                                         CancellationToken cancellationToken = default)
    {
        #region Model State Validation

        if (ModelState.IsValid)
        {
            var result = await Mediator.Send(new EditCurrentUserInfoCommand()
            {
                UserAvatar = UserAvatar,
                UserInfo = edit
            },
            cancellationToken
            );

            switch (result)
            {
                case UserPanelEditUserInfoResult.NotValidImage:
                    TempData[ErrorMessage] = "تصویر انتخاب شده صحیح نمی باشد.";
                    break;

                case UserPanelEditUserInfoResult.UserNotFound:
                    TempData[ErrorMessage] = "کابری یافت نشده است.";
                    return RedirectToAction("Index", "Home", new { area = "UserPanel" });

                case UserPanelEditUserInfoResult.Success:
                    TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                    return RedirectToAction("Index", "Home", new { area = "UserPanel" });

                case UserPanelEditUserInfoResult.NationalId:
                    TempData[ErrorMessage] = "وارد کردن کدملی الزامسیت.";
                    break;

                case UserPanelEditUserInfoResult.NotValidNationalId:
                    TempData[ErrorMessage] = "کدملی وارد شده صحیح نمی باشد.";
                    break;
            }
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return View(edit);
    }

    #endregion

    #region Change Password

    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangePassword(ChangeUserPasswordDTO model,
                                                    CancellationToken cancellationToken)
    {
        #region Model State Validation

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        #endregion

        #region change Password

        var result = await Mediator.Send(new ChangeUserPasswordDTOCommand()
        {
            CurrentPassword = model.CurrentPassword,
            NewPassword = model.NewPassword,
            ReNewPassword = model.ReNewPassword,
            UserId = User.GetUserId(),
        });

        switch (result)
        {
            case ChangeUserPasswordResponse.Success:
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction("Logout", "Account");

            case ChangeUserPasswordResponse.UserNotFound:
                TempData[ErrorMessage] = "کاربری یافت نشده است.";
                break;

            case ChangeUserPasswordResponse.WrongPassword:
                TempData[ErrorMessage] = "کلمه ی عبور وارد شده صحیح نمی باشد.";
                break;

            default:
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                break;
        }

        #endregion

        return View(model);
    }

    #endregion

    #endregion
}
