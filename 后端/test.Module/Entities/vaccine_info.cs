using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    /// <summary>
    /// 疫苗种类
    /// </summary>
    public class vaccine_info
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string? virus_name { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public string? manufacture { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public string? type { get; set; }
    }
}
