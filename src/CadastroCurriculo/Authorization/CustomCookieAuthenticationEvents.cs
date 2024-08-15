using Core.Enums;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CadastroCurriculo.Authorization;

public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
{
    private readonly IUserService _userService;

    public CustomCookieAuthenticationEvents(IUserService userService)
    {
        _userService = userService;
    }

    public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
    {
        if (context.HttpContext.User == null)
        {
            return;
        }

        var updatedAtClaimValue = GetClaimValueOrDefault(context, "UpdatedAtTicks");

        if (string.IsNullOrEmpty(updatedAtClaimValue))
        {
            return;
        }

        var userId = GetClaimValueOrDefault(context, "Id");

        if (string.IsNullOrEmpty(userId))
        {
            return;
        }

        var updatedAt = long.Parse(updatedAtClaimValue);

        var user = await _userService.GetById(int.Parse(userId));

        if (user.Status == Status.Disable)
        {
            context.RejectPrincipal();
            await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return;
        }

        if ((user.UpdatedAt ?? user.CreatedAt).Ticks > updatedAt)
        {
            var claimPrincipal = ClaimsPrincipalFactory.Create(user);

            context.ReplacePrincipal(claimPrincipal);
            context.ShouldRenew = true;
        }
    }

    private static string GetClaimValueOrDefault(
        CookieValidatePrincipalContext context,
        string claimType
    )
    {
        var claim = context.Principal.Claims
            .Where(x => string.Equals(x.Type, claimType, StringComparison.OrdinalIgnoreCase))
            .FirstOrDefault();

        return claim?.Value;
    }
}
