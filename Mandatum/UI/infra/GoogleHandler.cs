using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mandatum.infra
{
    public class GoogleHandler:IResponseHandler
    {
        public IActionResult Login()
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> GithubResponse()
        {
            throw new System.NotImplementedException();
        }
    }
}