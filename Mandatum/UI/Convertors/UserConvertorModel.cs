using Application;
using Mandatum.ViewModels;

namespace Mandatum.Convertors
{
    public class UserConvertorModel: IConvertor<UserRecord, LoginModel>
    {

        public UserRecord Convert(LoginModel source)
        {
            return new UserRecord() {Email = source.Email};
        }

        public LoginModel Convert(UserRecord source)
        {
            return new LoginModel() {Email = source.Email};
        }
    }
}