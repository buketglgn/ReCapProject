using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDTO userForRegister, string password);

        IDataResult<User> Login(UserForLoginDTO userForLogin);
        IResult Exists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
