using ClinicSalamat.Application.Common.IUnitOfWork;
using ClinicSalamat.Application.Contract.DTOs.SiteSide.Account;
using ClinicSalamat.Application.Security;
using ClinicSalamat.Application.Utilities.Security;
using ClinicSalamat.Domain.IRepositories.User;

namespace ClinicSalamat.Application.CQRS.WebMVC.SiteSide.Account.Command;

public record RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResult>
{
    #region Ctor

    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(IUserQueryRepository userQueryRepository,
                                      IUserCommandRepository userCommandRepository,
                                      IUnitOfWork unitOfWork)
    {
        _userCommandRepository = userCommandRepository;
        _userQueryRepository = userQueryRepository;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<RegisterUserResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        #region Check Is Exist User By Mobile

        var userExist = await _userQueryRepository.IsMobileExist(request.Mobile.Trim().ToLower(), cancellationToken);
        if (userExist) return RegisterUserResult.MobileExist;

        #endregion

        #region Add User 

        Domain.Entities.UsersAgg.User user = new Domain.Entities.UsersAgg.User(
            username: request.Mobile.Trim().ToLower().SanitizeText(),
            mobile : request.Mobile.Trim().ToLower().SanitizeText(),
            expireMobileSMSDateTime : DateTime.Now,
            isActive : true,
            password : PasswordHelper.EncodePasswordMd5(request.Password),
            mobileActivationCode : new Random().Next(10000, 999999).ToString()
            );

        await _userCommandRepository.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync();

        #endregion

        return RegisterUserResult.Success;
    }
}
