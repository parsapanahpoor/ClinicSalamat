using ClinicSalamat.Domain.IRepositories.User;
using ClinicSalamat.Infrastructure.EfCore.ApplicationDbContext;
namespace ClinicSalamat.Infrastructure.EfCore.Repositories.User;

public class UserCommandRepository : CommandGenericRepository<Domain.Entities.UsersAgg.User>, IUserCommandRepository
{
    #region Ctor

    private readonly ClinicSalamatDbContext _context;

    public UserCommandRepository(ClinicSalamatDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion
}
