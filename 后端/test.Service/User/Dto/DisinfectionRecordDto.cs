using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Service.User.Dto
{
    public class DisinfectionRecordInputDto
    {
        public DateTime? date { get; set; }
        public string? pos_id { get; set; }
        public string? disinfection { get; set; }
    }
}
