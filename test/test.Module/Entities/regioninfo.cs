using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Module.Entities
{
    public class regioninfo
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string pos_id { get; set; }
        public string? province { get; set; }
        public string? city { get; set; }
        public string? area { get; set; }
        public string? Street { get; set; }
    }
}
