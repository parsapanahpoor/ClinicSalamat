using ClinicSalamat.Application.Contract.DTOs.AdminSide.User;
using ClinicSalamat.Domain.IRepositories.User;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.User.Query;

public record FillEditCurrentUserInfoQueryHandler : IRequestHandler<FillEditCurrentUserInfoQuery, EditUserInfoDTO>
{
    #region Ctor

    private readonly IUserQueryRepository _userQueryRepository;

    public FillEditCurrentUserInfoQueryHandler(IUserQueryRepository userQueryRepository)
    {
        _userQueryRepository = userQueryRepository;
    }

    #endregion

    public async Task<EditUserInfoDTO?> Handle(FillEditCurrentUserInfoQuery request, CancellationToken cancellationToken)
    {
        #region Get User By Id

        var user = await _userQueryRepository.GetByIdAsync(cancellationToken, request.userId);
        if (user == null) return null;

        #endregion

        #region Fill View Model

        EditUserInfoDTO model = new EditUserInfoDTO()
        {
            Mobile = user.Mobile,
            UserId = user.Id,
            AvatarName = user.Avatar,
            username = user.Username,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        if (!string.IsNullOrEmpty(user.NationalId))
        {
            model.NationalId = user.NationalId;
        }

        #endregion

        return model;
    }
}
