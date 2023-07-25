using coreMvcSecurityProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace coreMvcSecurityProject.Security
{
    public class SecurityManager
    {
        public async void SignIn(HttpContext httpContext, Account account) 
        {
            ClaimsIdentity identity = new ClaimsIdentity(getUserClaims(account), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }

        public async void SignOut(HttpContext httpContext) 
        {
            await httpContext.SignOutAsync();
        }

        public IEnumerable<Claim> getUserClaims(Account account) 
        {
            List<Claim > claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, account.Username));
            foreach(var role in account.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
    }
}
