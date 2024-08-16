using Core.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CadastroCurriculo.Authorization;

public class ClaimsPrincipalFactory
{
    public static ClaimsPrincipal Create(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.MobilePhone, user.Phone),
            new Claim("Id", user.Id.ToString()),
            new Claim("AtualizadoEmTicks", (user.UpdatedAt ?? user.CreatedAt).Ticks.ToString()),
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        return new ClaimsPrincipal(claimsIdentity);
    }
}