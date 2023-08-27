using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Common;
using test.Service.Management.DisinfectionRecord;
using test.Module.Entities;
using test.Service.User.Dto;

namespace test.WebAPI.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class DisinfectionController : ControllerBase
    {
        private readonly IDisinfectionService _disinfectionService;

        public DisinfectionController( IDisinfectionService disinfectionService)
        {
            _disinfectionService = disinfectionService;
        }

        [HttpPost("AddDisinfectionRecord")]
        public ActionResult<string> AddDisinfectionRecord([FromBody]  DisinfectionRecordInputDto input)
        {
            if( input == null)
            {
                return BadRequest("Null input");
            }
           
            // 生成记录
            var record = new disinfection_record
            {
                date = input.date,
                pos_id = input.pos_id,
                disinfection = input.disinfection
            };

            bool result=_disinfectionService.AddRecord(record);
            if (result == true)
                return Ok("Disinfection record added successfully");
            else
                return BadRequest("Fail to insert into database");
        }
    }

}
