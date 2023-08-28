using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    /// <summary>
    /// 核酸检测记录
    /// </summary>
    public class nuclear_test_info
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string? user_id { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public string? test_time { get; set; }
        public string? test_tube_ID { get; set; }
        public string? test_result { get; set; }
    }
}
