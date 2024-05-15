namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.User.Command;

public record DeleteUserCommand(ulong userId) : IRequest<bool>;
