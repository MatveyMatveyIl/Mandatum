using System.Collections.Generic;
using Application;
using Mandatum.ViewModels;

namespace Mandatum.Convertors
{
    public class UserConverterRegister:IConverter<UserRecord, RegisterModel>
    {
        public UserRecord Convert(RegisterModel source)
        {
            return new UserRecord() {Email = source.Email, Boards = new List<BoardRecord>()};
        }

        public RegisterModel Convert(UserRecord source)
        {
            return new RegisterModel() {Email = source.Email};
        }
    }
}