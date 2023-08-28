using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using test.Module.Entities;
using test.Service.Token;
using test.Service.User;

namespace test.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserHealthController : ControllerBase
    {
        public IUserService _userService;
        public IJWTService _jwtService;
        public UserHealthController(IUserService userService, IJWTService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }
        [HttpGet]
        [Authorize]
        public string GetUserHealthInfo()
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
            List<user_health_state> user_Health_States = new List<user_health_state>();
            user_Health_States= _userService.GetUserHealthInfo(id);
            data = JsonConvert.SerializeObject(new
            {
                code = 200,
                Message = "success",
                id = user_Health_States[0].id,
                current_status = user_Health_States[0].current_status,
                nucieic_acid_test_result = user_Health_States[0].nucieic_acid_test_result,
                vaccination_status= user_Health_States[0].vaccination_status
            });
            return data;
        }
    }
}
