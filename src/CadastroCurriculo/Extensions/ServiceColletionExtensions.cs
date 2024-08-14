using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Services;
using DataBase.Repositories;

namespace SindicosInterno.Extensions;

public static class ServiceColletionExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ICurricolumRepository, CurricolumRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ICurricolumService, CurricolumService>();
    }
}
