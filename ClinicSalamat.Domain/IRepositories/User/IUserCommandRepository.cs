namespace ClinicSalamat.Domain.IRepositories.User;

public interface IUserCommandRepository
{
    #region General Methods

    Task AddAsync(Entities.UsersAgg.User user, CancellationToken cancellationToken);

    void Update(Entities.UsersAgg.User user);

    #endregion
}
