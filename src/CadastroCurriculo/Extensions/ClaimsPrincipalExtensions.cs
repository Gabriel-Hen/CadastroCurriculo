using System.Security.Claims;

namespace CadastroCurriculo.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string Id(this ClaimsPrincipal claimsPrincipal)
    {
        return GetClaimValueOrDefault(claimsPrincipal, "Id")?.Value;
    }

    public static string Name(this ClaimsPrincipal claimsPrincipal)
    {
        return GetClaimValueOrDefault(claimsPrincipal, ClaimTypes.Name)?.Value;
    }

    public static string Email(this ClaimsPrincipal claimsPrincipal)
    {
        return GetClaimValueOrDefault(claimsPrincipal, ClaimTypes.Email)?.Value;
    }

    private static Claim GetClaimValueOrDefault(
        ClaimsPrincipal claimsPrincipal,
        string claimType
    )
    {
        return claimsPrincipal.Claims.SingleOrDefault(x => string.Equals(claimType, x.Type));
    }
}