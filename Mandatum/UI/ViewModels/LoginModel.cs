using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Mandatum.infra;

namespace Mandatum.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Введите Email")]
        public string Email { get; set; }
         
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
         
        public string ReturnUrl { get; set; }
        public string key { get; set; }
        public string scheme { get; set; }

        public IEnumerable<IOAuthType> AuthTypes = new IOAuthType[] {new GitAuthType(), new GoogleAuthType()};
    }
}