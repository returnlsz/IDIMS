using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    /// <summary>
    /// 单个疫苗信息
    /// </summary>
    public class one_vaccine_info
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string? vaccine_id { get; set; }
        public int is_safe { get; set; }
        public string? medical_point_id { get; set; }
        public DateTime? production_date { get; set; }
        public int shlf_life { get; set; }
        public int vaccinated { get; set; }
        public DateTime? vaccinated_time { get; set; }
        public string? vaccine_type_id { get; set; }
    }
}
