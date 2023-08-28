using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    /// <summary>
    /// 核酸检测试管信息表
    /// </summary>
    public class nuclear_pipe_info
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string? test_tube_ID { get; set; }
        public string? user_ID { get; set; }
        public string? test_time { get; set; }
    }
}
