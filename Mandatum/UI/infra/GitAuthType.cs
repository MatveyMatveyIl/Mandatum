using AspNet.Security.OAuth.GitHub;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Mandatum.infra
{
    public class GitAuthType : IOAuthType
    {
        public  AuthType Name { get; set; } = AuthType.Github;
        public  string Image { get; set; } = "/images/git.png";
        public  string Scheme { get; set; } = GitHubAuthenticationDefaults.AuthenticationScheme;
        public  string EmailKey { get; set; } = "name";
        
    }
}