using System.ComponentModel.DataAnnotations;

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
    }
}