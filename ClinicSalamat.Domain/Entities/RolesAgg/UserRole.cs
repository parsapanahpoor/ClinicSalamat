﻿namespace ClinicSalamat.Domain.Entities.RoleAgg;

public class UserRole : BaseEntities<ulong>
{
    #region properties

    public ulong UserId { get; set; }

    public ulong RoleId { get; set; }

    #endregion
}
