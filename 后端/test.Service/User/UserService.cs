using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using test.Common.Db;
using test.Module.Entities;
using test.Service.User.Dto;

namespace test.Service.User
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Users> CheckLogin(LoginDto login)
        {
            return await DbContext.db.Queryable<Users>().FirstAsync(m => m.id.Equals(login.id) && m.pwd.Equals(login.pwd));
        }
        public UserDto AddUser(InputUserDto input)
        {
            Users user = TransInputDto(input);
            if (!DbContext.db.Queryable<Users>().Any(m => m.id.Equals(input.id)))
            {
                DbContext.db.Insertable(user).ExecuteCommand();
                return _mapper.Map<UserDto>(user);
            }
            else
                throw new Exception("id已存在");
        }
        private Users TransInputDto(InputUserDto input)
        {
            var user = _mapper.Map<Users>(input);
            return user;
        }
    }
}
