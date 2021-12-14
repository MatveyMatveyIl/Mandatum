using System;
using System.ComponentModel.DataAnnotations;

namespace Mandatum.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Введите Email")]
        public string Email { get; set; }
         
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
         
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        public Guid Id { get; set; }
    }
}