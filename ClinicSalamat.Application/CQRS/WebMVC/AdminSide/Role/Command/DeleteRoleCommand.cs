namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.Role.Command;

public record DeleteRoleCommand(ulong roleId) : IRequest<bool>;
