using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Module.Entities
{
    public class Users
    {
        [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
        public string id { get; set; }
        public string pwd { get; set; }
    }
}
