using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IResult UserExists(string email); //kullanıcı var mı
        IDataResult<User> Register(RegisterDto registerDto, string password);
        IDataResult<User> Login(LoginDto loginDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
