using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Common;
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
            if(currCode==null)
            {
                return "";
            }
            if(currCode.ToString()==validateCode)
            {
                LoginDto loginDto = new LoginDto();
                loginDto.id = id;
                loginDto.pwd = pwd;
                var user = _userService.CheckLogin(loginDto).Result;
                if(user !=null)
                {
                    return _jwtService.GetToken(user);
                }
                else
                {
                    return "";
                }
            }
            return "";
        }
    }
}
