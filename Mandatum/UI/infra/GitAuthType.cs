using AspNet.Security.OAuth.GitHub;

namespace Mandatum.infra
{
    public class GitAuthType : IOAuthType
    {
        public AuthType Name { get; set; } = AuthType.Github;
        public string Image { get; set; } = "/images/git.png";
        public string Responser { get; set; } = "GithubResponse";
        public string Scheme { get; set; } = GitHubAuthenticationDefaults.AuthenticationScheme;
        public GitAuthType()
        {
            
        }
    }
}