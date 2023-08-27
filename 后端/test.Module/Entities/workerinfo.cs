using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    /// <summary>
    /// 工作人员
    /// </summary>
    public class workerinfo
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string? id { get; set; }
        public string? pos_id { get; set; }
        public string? medical_point_id { get; set; }
        public string? password { get; set; }
        public string? phone_number { get; set; }
    }
}
