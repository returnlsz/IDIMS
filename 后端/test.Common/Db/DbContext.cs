using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace test.Common.Db
{
    public class DbContext
    {
        public static SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = "Data Source=127.0.0.1:1521/orcl;Persist Security Info=True;User ID=hr;PassWord=123;",
            DbType = DbType.Oracle,
            IsAutoCloseConnection = true
        });
    }
}
