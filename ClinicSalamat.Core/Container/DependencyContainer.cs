#region Usings

using ClinicSalamat.Application.Common.IUnitOfWork;
using ClinicSalamat.Domain.IRepositories.Role;
using ClinicSalamat.Domain.IRepositories.User;
using ClinicSalamat.Infrastructure.EfCore.Repositories.Role;
using ClinicSalamat.Infrastructure.EfCore.Repositories.User;
using ClinicSalamat.Infrastructure.EfCore.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicSalamat.Core;

#endregion

public static class DependencyContainer
{
    public static void ConfigureDependencies(IServiceCollection services)
    {
        #region Repositories

        //User
        services.AddScoped<IUserCommandRepository, UserCommandRepository>();
        services.AddScoped<IUserQueryRepository, UserQueryRepository>();

        //Role
        services.AddScoped<IRoleCommandRepository, RoleCommandRepository>();
        services.AddScoped<IRoleQueryRepository, RoleQueryRepository>();

        #endregion

        #region Unit Of Work 

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        #endregion
    }
}
