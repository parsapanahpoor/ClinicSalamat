using ClinicSalamat.Application.Common.IUnitOfWork;
using ClinicSalamat.Application.Contract.DTOs.AdminSide.User;
using ClinicSalamat.Application.Security;
using ClinicSalamat.Domain.IRepositories.User;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.User.Command;

public record ChangeUserPasswordDTOCommandHandler : IRequestHandler<ChangeUserPasswordDTOCommand, ChangeUserPasswordResponse>
{
    #region Ctor

    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeUserPasswordDTOCommandHandler(IUserCommandRepository userCommandRepository,
                                               IUserQueryRepository userQueryRepository,
                                               IUnitOfWork unitOfWork)
    {
        _userCommandRepository = userCommandRepository;
        _userQueryRepository = userQueryRepository;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<ChangeUserPasswordResponse> Handle(ChangeUserPasswordDTOCommand request, CancellationToken cancellationToken)
    {
        #region Get User By Id

        var user = await _userQueryRepository.GetByIdAsync(cancellationToken, request.UserId);
        if (user == null) return ChangeUserPasswordResponse.UserNotFound;

        #endregion

        #region Change Password

        if (user.Password != PasswordHelper.EncodePasswordMd5(request.CurrentPassword))
        {
            return ChangeUserPasswordResponse.WrongPassword;
        }

        user.Password = PasswordHelper.EncodePasswordMd5(request.NewPassword);

        _userCommandRepository.Update(user);
        await _unitOfWork.SaveChangesAsync();

        #endregion

        return ChangeUserPasswordResponse.Success;
    }
}
