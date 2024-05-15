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

        Domain.Entities.UsersAgg.User user = new Domain.Entities.UsersAgg.User()
        {
            Username = request.Mobile.Trim().ToLower().SanitizeText(),
            Mobile = request.Mobile.Trim().ToLower().SanitizeText(),
            ExpireMobileSMSDateTime = DateTime.Now,
            IsActive = true,
            Password = PasswordHelper.EncodePasswordMd5(request.Password),
            MobileActivationCode = new Random().Next(10000, 999999).ToString(),
        };

        await _userCommandRepository.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync();

        #endregion

        return RegisterUserResult.Success;
    }
}
