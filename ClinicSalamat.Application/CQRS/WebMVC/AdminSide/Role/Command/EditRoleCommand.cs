using ClinicSalamat.Application.Contract.DTOs.AdminSide.Role;

namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.Role.Command;

public class EditRoleCommand : IRequest<EditRoleResult>
{
    #region properties

    public string Title { get; set; }

    public string RoleUniqueName { get; set; }

    public List<ulong>? Permissions { get; set; }

    public ulong Id { get; set; }

    #endregion
}
