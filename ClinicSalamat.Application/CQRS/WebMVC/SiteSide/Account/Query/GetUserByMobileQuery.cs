namespace ClinicSalamat.Application.CQRS.WebMVC.SiteSide.Account.Query;

public class GetUserByMobileQuery : IRequest<Domain.Entities.UsersAgg.User>
{
    public string Mobile { get; set; }
}
