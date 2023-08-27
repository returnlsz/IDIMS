using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Module.Entities;
using test.Service.User.Dto;

namespace test.Service.User
{
    public interface IUserService
    {
        //登录
        Task<Users> CheckLogin(LoginDto login);
        //注册
        UserDto AddUser(InputUserDto input);
    }
}
