using ClinicSalamat.Application.Common.IUnitOfWork;
using ClinicSalamat.Domain.IRepositories.User;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.User.Command;

public record DeleteUserCommandHanlder : IRequestHandler<DeleteUserCommand, bool>
{
    #region Ctor

    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHanlder(IUserQueryRepository userQueryRepository,
                                    IUserCommandRepository userCommandRepository,
                                    IUnitOfWork unitOfWork)
    {
        _userCommandRepository = userCommandRepository;
        _userQueryRepository = userQueryRepository;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        //Get User By Id 
        var userOldInfos = await _userQueryRepository.GetByIdAsync(cancellationToken, request.userId);
        if (userOldInfos == null) return false;

        userOldInfos.IsDelete = true;

        _userCommandRepository.Update(userOldInfos);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
