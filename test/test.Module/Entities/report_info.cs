using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Module.Entities
{
    public class report_info
    {
        public DateTime? time { get; set; }
        public string? user_id { get; set; }

        public int? state { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public string message_id { get; set; }
        public string? content { get; set; }
    }
}
