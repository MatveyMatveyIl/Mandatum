using System.Collections.Generic;
using AspNet.Security.OAuth.GitHub;
using Microsoft.AspNetCore.Authentication.Google;

namespace Mandatum.infra
{
    public static class LoginParams
    {
        public static Dictionary<AuthType, string> Responsers = new Dictionary<AuthType, string>()
        {
            {AuthType.Github, "GithubResponse"},
            {AuthType.Google, "GoogleResponse"},
            
        };
        
        public static Dictionary<AuthType, string> Schemes = new Dictionary<AuthType, string>()
        {
            {AuthType.Google, GoogleDefaults.AuthenticationScheme},
            {AuthType.Github,  GitHubAuthenticationDefaults.AuthenticationScheme}
        };
    }
}