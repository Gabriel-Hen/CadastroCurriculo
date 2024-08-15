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
        services.AddTransient<IProfessionalExperienceRepository, ProfessionalExperienceRepository>();
        services.AddTransient<ICourseRepository, CourseRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ICurricolumService, CurricolumService>();
        services.AddTransient<IProfessionExperienceService, ProfessionalExperienceService>();
        services.AddTransient<ICourseService, CourseService>();
    }
}
