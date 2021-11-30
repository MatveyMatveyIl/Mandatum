using Application;
using Mandatum.ViewModels;

namespace Mandatum.Convertors
{
    public class UserConvertorModel
    {
        public UserRecord ConvertToUserRecord(LoginModel model)
        {
            return new UserRecord() {Email = model.Email, Password = model.Password};
        }
    }
}