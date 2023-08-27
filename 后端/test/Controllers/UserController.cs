using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Service.User;
using test.Service.User.Dto;

namespace test.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public ActionResult<UserDto> Regist([FromBody] InputUserDto input)
        {
            try
            {
                var res = _userService.AddUser(input);
                return res;
            }
            catch (Exception ex)
            {
                JsonResult result = new JsonResult(ex)
                {
                    StatusCode = 201
                };
                return result;
            }
        }
    }
}