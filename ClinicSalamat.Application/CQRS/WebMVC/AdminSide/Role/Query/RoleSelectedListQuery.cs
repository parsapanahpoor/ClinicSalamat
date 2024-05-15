using ClinicSalamat.Application.Contract.DTOs.Common;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.Role.Query;

public record RoleSelectedListQuery : IRequest<List<SelectListViewModel>>
{
}
