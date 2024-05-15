namespace ClinicSalamat.Application.CQRS.WebMVC.AdminSide.Role.Command;

public class CreateRoleCommand : IRequest<bool>
{
    #region properties

    public string Title { get; set; }

    public string RoleUniqueName { get; set; }

    public List<ulong>? Permissions { get; set; }

    #endregion
}
