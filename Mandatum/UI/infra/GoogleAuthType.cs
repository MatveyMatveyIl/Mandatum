using Microsoft.AspNetCore.Authentication.Google;

namespace Mandatum.infra
{
    public class GoogleAuthType: IOAuthType
    {
        public AuthType Name { get; set; } = AuthType.Google;
        public string Image { get; set; } = "/images/google_colored.png";
        public string Scheme { get; set; } = GoogleDefaults.AuthenticationScheme;

        public GoogleAuthType()
        {
            
        }
    }
    
}