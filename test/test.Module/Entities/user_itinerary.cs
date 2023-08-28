using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    /// <summary>
    /// 用户行程
    /// </summary>
    public class user_itinerary
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string id { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public string pos_id { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public DateTime? time { get; set; }
    }
}
