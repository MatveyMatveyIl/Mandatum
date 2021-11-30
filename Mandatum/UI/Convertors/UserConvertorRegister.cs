using Application;
using Mandatum.ViewModels;

namespace Mandatum.Convertors
{
    public class UserConvertorRegister
    {
        public UserRecord ConvertToUserRecord(RegisterModel model)
        {
            return new UserRecord() {Email = model.Email, Password = model.Password};
        }
    }
}