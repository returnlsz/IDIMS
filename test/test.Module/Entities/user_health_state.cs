using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    /// <summary>
    /// 用户健康状态
    /// </summary>
    public class user_health_state
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string id { get; set; }
        public string? current_status { get; set; }
        public string? nucieic_acid_test_result { get; set; }
        public int? vaccination_status { get; set; }
    }
}
