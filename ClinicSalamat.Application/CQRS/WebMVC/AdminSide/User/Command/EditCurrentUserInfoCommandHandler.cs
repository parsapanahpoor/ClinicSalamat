using ClinicSalamat.Application.Common.IUnitOfWork;
using ClinicSalamat.Application.Contract.DTOs.AdminSide.User;
using ClinicSalamat.Application.Contract.StaticTools;
using ClinicSalamat.Application.Extensions;
using ClinicSalamat.Application.Generators;
using ClinicSalamat.Application.Utilities.Security;
using ClinicSalamat.Domain.IRepositories.User;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.User.Command;

public record EditCurrentUserInfoCommandHandler : IRequestHandler<EditCurrentUserInfoCommand, UserPanelEditUserInfoResult>
{
    #region Ctor

    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EditCurrentUserInfoCommandHandler(IUserQueryRepository userQueryRepository,
                                             IUserCommandRepository userCommandRepository,
                                             IUnitOfWork unitOfWork)
    {
        _userCommandRepository = userCommandRepository;
        _userQueryRepository = userQueryRepository;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<UserPanelEditUserInfoResult> Handle(EditCurrentUserInfoCommand request, CancellationToken cancellationToken)
    {
        #region Data Valdiation

        var user = await _userQueryRepository.GetByIdAsync(cancellationToken, request.UserInfo.UserId);
        if (user == null) return UserPanelEditUserInfoResult.UserNotFound;

        if (request.UserAvatar != null)
        {
            if (!string.IsNullOrEmpty(user.Avatar))
            {
                user.Avatar.DeleteImage(FilePaths.UserAvatarPathServer, FilePaths.UserAvatarPathThumbServer);
            }

            var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(request.UserAvatar.FileName);
            request.UserAvatar.AddImageToServer(imageName, FilePaths.UserAvatarPathServer, 270, 270, FilePaths.UserAvatarPathThumbServer);
            user.Avatar = imageName;
        }

        if (string.IsNullOrEmpty(request.UserInfo.NationalId)) return UserPanelEditUserInfoResult.NationalId;

        if (!string.IsNullOrEmpty(request.UserInfo.NationalId) &&
            !await _userQueryRepository.IsValidNationalIdForUserEditByAdmin(request.UserInfo.NationalId, user.Id, cancellationToken))
        {
            return UserPanelEditUserInfoResult.NotValidNationalId;
        }

        #endregion

        #region Update User Field

        user.Username = request.UserInfo.username.SanitizeText();
        user.FirstName = request.UserInfo.FirstName.SanitizeText();
        user.LastName = request.UserInfo.LastName.SanitizeText();
        user.NationalId = request.UserInfo.NationalId;

        _userCommandRepository.Update(user);
        await _unitOfWork.SaveChangesAsync();

        #endregion

        return UserPanelEditUserInfoResult.Success;
    }
}
