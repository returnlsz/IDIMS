using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    /// <summary>
    /// 普通用户表
    /// </summary>
    public class userinfo
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string? id { get; set; }
        public string? name { get; set; }
        public string? gender { get; set; }
        public string? password { get; set; }
        public string? phone_number { get; set; }
    }
}
