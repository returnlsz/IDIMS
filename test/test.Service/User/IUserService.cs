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
        //上传抗原并返回是否成功
        int CheckAndUploadantigen(string id, DateTime test_time, string test_result);
        //用户举报
        int UserPutReport(DateTime time, string id, string content);
        //用户上传行程
        int UserUploadRouting(string id, string pos_id, DateTime time);
        //根据pos_id获取地区信息
        List<regioninfo> PosIdGetLocation(string pos_id);
        //获取用户健康状态
        List<user_health_state> GetUserHealthInfo(string id);
    }
}
