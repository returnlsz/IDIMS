using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    /// <summary>
    /// 反馈信息
    /// </summary>
    internal class feedback_info
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string? user_id { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public DateTime? send_time { get; set; }
        public string? feedback_content { get; set; }
    }
}
