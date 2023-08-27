using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    /// <summary>
    /// 用户身份绑定
    /// </summary>
    public class user_certification
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string? id { get; set; }
        public string? identity_number { get; set; }
    }
}
