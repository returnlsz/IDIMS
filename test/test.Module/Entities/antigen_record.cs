using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    /// <summary>
    /// 抗原检测表
    /// </summary>
    public class antigen_record
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string? user_id { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public DateTime test_time { get; set; }
        public string? test_result { get; set; }
    }
}
