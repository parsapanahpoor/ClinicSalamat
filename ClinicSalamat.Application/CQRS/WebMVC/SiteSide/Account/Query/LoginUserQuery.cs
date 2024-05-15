using ClinicSalamat.Application.Contract.DTOs.SiteSide.Account;

namespace ClinicSalamat.Application.CQRS.WebMVC.SiteSide.Account.Query;

public class LoginUserQuery() : IRequest<LoginUserResult>
{
    public string Mobile { get; set; }
    public string Password { get; set; }
}