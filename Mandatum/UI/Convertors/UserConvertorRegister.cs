using Application;
using Mandatum.ViewModels;

namespace Mandatum.Convertors
{
    public class UserConvertorRegister:IConvertor<UserRecord, RegisterModel>
    {
        public UserRecord Convert(RegisterModel source)
        {
            return new UserRecord() {Email = source.Email};
        }

        public RegisterModel Convert(UserRecord source)
        {
            return new RegisterModel() {Email = source.Email};
        }
    }
}