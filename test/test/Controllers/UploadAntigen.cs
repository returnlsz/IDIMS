using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using test.Service.Token;
using test.Service.User;

namespace test.WebAPI.Controllers
{
    /// <summary>
    /// 用户上传抗原
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class Uploadantigen : ControllerBase
    {
        public IUserService _userService;
        public IJWTService _jwtService;
        public Uploadantigen(IUserService userService, IJWTService jwtService) {
            _userService = userService;
            _jwtService = jwtService;
        }
        [HttpGet]
        [Authorize]
        public string UploadAntigen(DateTime test_time,string test_result)
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
            ///返回受影响的行数
            int result= _userService.CheckAndUploadantigen(id, test_time, test_result);
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
