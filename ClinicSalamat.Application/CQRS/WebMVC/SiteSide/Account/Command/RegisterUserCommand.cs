using ClinicSalamat.Application.Contract.DTOs.SiteSide.Account;

namespace ClinicSalamat.Application.CQRS.WebMVC.SiteSide.Account.Command;

public record RegisterUserCommand : IRequest<RegisterUserResult>
{
    public string Password { get; set; }
    public string Mobile { get; set; }
}
