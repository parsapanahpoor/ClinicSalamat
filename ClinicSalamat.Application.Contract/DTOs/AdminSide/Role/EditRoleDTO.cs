using System.ComponentModel.DataAnnotations;

namespace ClinicSalamat.Application.Contract.DTOs.AdminSide.Role;

public record EditRoleDTO
{
    #region properties

    public string Title { get; set; }

    public string RoleUniqueName { get; set; }

    public List<ulong>? Permissions { get; set; }

    public ulong Id { get; set; }

    #endregion
}

public enum EditRoleResult
{
    Success,
    RoleNotFound,
    UniqueNameExists
}