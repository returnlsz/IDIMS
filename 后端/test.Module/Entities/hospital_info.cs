using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    /// <summary>
    /// 医疗点信息
    /// </summary>
    public class hospital_info
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string? id { get; set; }
        public string? name { get; set; }
        public int max_num_of_people { get; set; }
        public int current_num_of_people { get; set; }
        public string? pos_id { get; set; }
    }
}
