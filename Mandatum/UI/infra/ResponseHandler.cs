using System.Collections.Generic;
using System.Linq;
using Application;
using AspNet.Security.OAuth.GitHub;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
namespace Mandatum.infra
{
    public class ResponseHandler
    {
        private static Dictionary<AuthTypes, string> TypesKeys = new Dictionary<AuthTypes, string>()
        {
            {AuthTypes.Github, "name"},
            {AuthTypes.Google, "emailaddres"}
        };

        public async Task Auth(UserManager<UserRecord> userManager, SignInManager<UserRecord> _signInManager,AuthenticateResult  response)
        {
            var email = ResponseHandler.GetEmail(AuthTypes.Github, response);
            var user = new UserRecord() {Email = email, UserName = email};
            if (await userManager.GetUserAsync(response.Principal) is null)
                await userManager.CreateAsync(user, "Qwer1%");

            await _signInManager.SignInAsync(user, false);
        }

        public static string GetEmail(AuthTypes type, AuthenticateResult response)
        {
            
            
            var email = response.Principal?.Identities.FirstOrDefault()
                ?.Claims
                .Where(claim => (claim.Type.Split("/").Last() == TypesKeys[type] ))
                .Select(claim => claim.Value.Split("/").Last())
                .FirstOrDefault();
            return email;
        }
    }

    public enum AuthTypes
    {
        Github,
        Google
    }
}