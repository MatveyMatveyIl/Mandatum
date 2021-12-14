using System.Security.Policy;
using System.Threading.Tasks;
using AspNet.Security.OAuth.GitHub;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Mandatum.infra
{
    public interface IResponseHandler
    {
        public IActionResult Login();

        public Task<IActionResult> GithubResponse();
    }
}