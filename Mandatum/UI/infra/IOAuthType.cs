using System.Security.Policy;
using System.Threading.Tasks;
using AspNet.Security.OAuth.GitHub;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Mandatum.infra
{
    public interface IOAuthType
    {
        public AuthType Name { get; set; }
        public string Image { get; set; }
        public string Scheme { get; set; }
        public string EmailKey { get; set; }
    }
}