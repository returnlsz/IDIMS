using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using test.Service.Token;
using test.Service.User;

namespace test.WebAPI.Controllers
{
    /// <summary>
    /// 用户上传行程
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserUploadRouting : ControllerBase
    {
        public IUserService _userService;
        public IJWTService _jwtService;
        public UserUploadRouting(IUserService userService, IJWTService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }
        [HttpGet]
        [Authorize]
        public string UploadRouting(DateTime time,string pos_id)
        {
            string token;
            string data;
            try
            {
                token = HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
            }
            catch (SecurityTokenExpiredException)
            {
                data = JsonConvert.SerializeObject(new { code = 400, ErrorMessage = "用户凭证已过期，请重新登陆" });
                return data;
            }
            catch (Exception)
            {
                data = JsonConvert.SerializeObject(new { code = 400, ErrorMessage = "无效令牌签名" });
                return data;
            }
            string id = _jwtService.DecodeToken(token);
            int result = _userService.UserUploadRouting(id,pos_id,time);
            if (result > 0)
            {
                data = JsonConvert.SerializeObject(new { code = 200, Message = "success" });
                return data;
            }
            else
            {
                data = JsonConvert.SerializeObject(new { code = 400, ErrorMessage = "数据库原因，抗原上传失败" });
                return data;
            }
        }

    }
}
