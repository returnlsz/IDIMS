using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Module.Entities;

namespace test.Service.Token
{
    public interface IJWTService
    {
        string GetToken(Users user);
    }
}
