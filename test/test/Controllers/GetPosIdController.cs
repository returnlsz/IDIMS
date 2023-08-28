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
    /// <summary>
    /// 根据pos_id获取对应地区的信息
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class GetPosIdController : ControllerBase
    {
        public IUserService _userService;
        public IJWTService _jwtService;
        public GetPosIdController(IUserService userService, IJWTService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }
        [HttpGet]
        [Authorize]
        public string GetPosId(string pos_id)
        {
            string data;
            List<regioninfo> Regioninfo = _userService.PosIdGetLocation(pos_id);

            data = JsonConvert.SerializeObject(new { code = 200, Message = "success" ,
            pos_id=pos_id,province= Regioninfo[0].province, city= Regioninfo[0].city,area= Regioninfo[0].area,Street= Regioninfo[0].Street
            });
            return data;
        }
    }
}
