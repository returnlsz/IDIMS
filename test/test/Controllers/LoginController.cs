using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using test.Common;
using test.Module.Entities;
using test.Service.Token;
using test.Service.User;
using test.Service.User.Dto;

namespace test.WebAPI.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        public IUserService _userService;
        public IJWTService _jwtService;
        public LoginController(IUserService userService, IJWTService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }
        [HttpGet]
        public IActionResult GetValidateCodeImages(string t)
        {
            System.Console.WriteLine(t);
            var validateCodeString = Tools.CreateValidateString();

            MemoryHelper.SetMemory(t, validateCodeString, 1);

            byte[] buffer = Tools.CreateValidateCodeBuffer(validateCodeString);
            return File(buffer, @"image/jpeg");
        }

        [HttpGet("{id}/{pwd}")]
        public string CheckLogin(string id,string pwd,string validateKey,string validateCode)
        {
            var currCode = MemoryHelper.GetMemory(validateKey);
            string data;
            if (currCode==null)
            {
                data = JsonConvert.SerializeObject(new { code = 400, ErrorMessage = "请输入验证码" });
                return data;
            }
            if(currCode.ToString()==validateCode)
            {
                LoginDto loginDto = new LoginDto();
                loginDto.id = id;
                loginDto.pwd = pwd;
                Users user = new Users();
                user.id = id;
                user.pwd = pwd;
                ///为了方便调试，将登陆直接设置为成功，用户名密码随便输
                data = JsonConvert.SerializeObject(new { code = 200, Token = _jwtService.GetToken(user) });
                return data;
                
                //var user = _userService.CheckLogin(loginDto).Result;
                if(user !=null)
                {
                    // 将对象序列化为JSON字符串
                    data = JsonConvert.SerializeObject(new { code=200, Token = _jwtService.GetToken(user) });
                    return data;
                }
                else
                {
                    data = JsonConvert.SerializeObject(new { code = 400, ErrorMessage="用户名不存在或密码错误" });
                    return data;
                }
            }
            data = JsonConvert.SerializeObject(new { code = 400, ErrorMessage = "验证码错误" });
            return data;
        }
    }
}
