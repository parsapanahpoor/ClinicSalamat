using ClinicSalamat.Application.Contract.DTOs.AdminSide.Role;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.Role.Query;

public record EditRoleQuery(ulong roleId) : IRequest<EditRoleDTO>;
