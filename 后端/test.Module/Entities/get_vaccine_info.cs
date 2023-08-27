using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    /// <summary>
    /// 接种疫苗记录
    /// </summary>
    public class get_vaccine_info
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string? id { get; set; }
        public string? vaccin_id { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public DateTime? vaccinate_time { get; set; }
        public int vaccinate_times { get; set; }
    }
}
