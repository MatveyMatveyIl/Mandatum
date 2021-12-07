using System.Collections.Generic;
using Application;
using Mandatum.ViewModels;

namespace Mandatum.Convertors
{
    public class UserConvertorModel: IConvertor<UserRecord, LoginModel>
    {

        public UserRecord Convert(LoginModel source)
        {
            return new UserRecord() {Email = source.Email, Boards = new List<BoardRecord>()};
        }

        public LoginModel Convert(UserRecord source)
        {
            return new LoginModel() { Email = source.Email};
        }
    }
}