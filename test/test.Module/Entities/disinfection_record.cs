using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    /// <summary>
    /// 消杀记录
    /// </summary>
    public class disinfection_record
    {
        [SugarColumn(IsPrimaryKey = true)]
        public DateTime? date { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public string? pos_id { get; set; }
        public string? disinfection { get; set; }
    }
}
