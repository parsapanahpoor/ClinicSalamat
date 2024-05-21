namespace ClinicSalamat.Domain.Entities.UsersAgg;

public class User : BaseEntities<ulong>
{
    #region properties

    public string? Username { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? NationalId { get; set; }

    public string? Mobile { get; set; }

    public string Password { get; set; }

    public string? Avatar { get; set; }

    public string MobileActivationCode { get; set; }

    public bool IsAdmin { get; set; } = false;

    public bool IsActive { get; set; } = false;

    public DateTime? ExpireMobileSMSDateTime { get; set; }

    #endregion

    protected User()
    {
            
    }

    public User(string username , string mobile , DateTime expireMobileSMSDateTime , bool isActive , string password , string mobileActivationCode)
    {
        Username = username;
        Mobile = mobile;
        ExpireMobileSMSDateTime = expireMobileSMSDateTime;
        IsActive = isActive;
        Password = password;
        MobileActivationCode = mobileActivationCode;
    }
}
