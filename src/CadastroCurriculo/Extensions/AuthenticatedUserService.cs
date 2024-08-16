using Core;

namespace CadastroCurriculo.Extensions;

public static class AuthenticatedUserService
{
    public static IServiceCollection AddAuthenticatedUser(this IServiceCollection services)
    {
        return services.AddScoped(x =>
        {
            var context = x.GetService<IHttpContextAccessor>();
            var user = context.HttpContext.User;

            return new AuthenticatedUser
            {
                Id = int.Parse(user.Id()),
                Name = user.Name(),
                Phone = user.Phone(),
            };
        });
    }
}