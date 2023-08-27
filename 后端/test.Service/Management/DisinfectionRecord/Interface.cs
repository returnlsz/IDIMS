using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Module.Entities;

namespace test.Service.Management.DisinfectionRecord
{
    public interface IDisinfectionService
    {
        bool AddRecord(disinfection_record record);
    }
}
