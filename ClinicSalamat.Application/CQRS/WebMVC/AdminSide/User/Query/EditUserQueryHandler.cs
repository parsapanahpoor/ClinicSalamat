using ClinicSalamat.Application.Contract.DTOs.AdminSide.User;
using ClinicSalamat.Domain.IRepositories.Role;
using ClinicSalamat.Domain.IRepositories.User;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.User.Query;

public record EditUserQueryHandler : IRequestHandler<EditUserQuery, EditUserDTO>
{
    #region Ctor 

    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IRoleQueryRepository _roleQueryRepository;

    public EditUserQueryHandler(IUserQueryRepository userQueryRepository,
                                IRoleQueryRepository roleQueryRepository)
    {
        _userQueryRepository = userQueryRepository;
        _roleQueryRepository = roleQueryRepository;
    }

    #endregion
    public async Task<EditUserDTO?> Handle(EditUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userQueryRepository.GetByIdAsync(cancellationToken, request.UserId);
        if (user == null) return null;

        return new EditUserDTO()
        {
            Avatar = user.Avatar,
            Id = user.Id,
            Mobile = user.Mobile,
            Password = user.Password,
            Username = user.Username,
            IsActive = user.IsActive,
            UserRoles = await _roleQueryRepository.GetUserSelectedRoleIdByUserId(user.Id, cancellationToken)
        };
    }
}
