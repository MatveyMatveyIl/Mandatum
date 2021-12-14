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
        private static Dictionary<AuthType, string> TypesKeys = new Dictionary<AuthType, string>()
        {
            {AuthType.Github, "name"},
            {AuthType.Google, "emailaddress"}
        };

        public async Task Auth(UserManager<UserRecord> userManager, SignInManager<UserRecord> _signInManager,AuthenticateResult  response, AuthType type )
        {
            var email = GetEmail(type, response);
            var user = new UserRecord() {Email = email, UserName = email};
            if (await userManager.GetUserAsync(response.Principal) is null)
                await userManager.CreateAsync(user, "Qwer1%");

            await _signInManager.SignInAsync(user, false);
        }

        public static string GetEmail(AuthType type, AuthenticateResult response)
        {
            
            
            var email = response.Principal?.Identities.FirstOrDefault()
                ?.Claims
                .Where(claim => (claim.Type.Split("/").Last() == TypesKeys[type] ))
                .Select(claim => claim.Value.Split("/").Last())
                .FirstOrDefault();
            return email;
        }
    }

    public enum AuthType
    {
        Github,
        Google
    }
}