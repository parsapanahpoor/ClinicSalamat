using ClinicSalamat.Application.Contract.DTOs.AdminSide.User;
namespace ClinicSalamat.Application.Contract.IApplicationServices.User;

public interface IUserApplicationService
{
    #region Admin Side Requirements

    Task<FilterUsersDTO> Filter_Users(FilterUsersDTO filter,
                                      CancellationToken cancellation);

    #endregion
}
