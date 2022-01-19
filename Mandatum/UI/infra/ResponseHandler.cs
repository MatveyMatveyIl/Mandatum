using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Application.Entities;

namespace Mandatum.infra
{
    public class ResponseHandler
    {
       

        public async Task Auth(UserManager<UserRecord> userManager, SignInManager<UserRecord> _signInManager,AuthenticateResult response, string emailKey)
        {
            var email = GetEmail(emailKey, response);
            var user = new UserRecord() {Email = email, UserName = email};
            if (await userManager.GetUserAsync(response.Principal) is null)
                await userManager.CreateAsync(user, "Qwer1%");

            await _signInManager.SignInAsync(user, false);
        }

        public static string GetEmail(string emailKey, AuthenticateResult response)
        {
            var email = response.Principal?.Identities.FirstOrDefault()
                ?.Claims
                .Where(claim => (claim.Type.Split("/").Last() ==emailKey ))
                .Select(claim => claim.Value.Split("/").Last())
                .FirstOrDefault();
            return email;
        }
    }

    public enum AuthType
    {
        Github,
        Google,
        Mandatum
    }
}