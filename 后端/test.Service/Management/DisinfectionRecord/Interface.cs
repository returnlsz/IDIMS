using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Module.Entities;

namespace test.Service.Management.DisinfectionRecord
{
    public interface IStaffService
    {
        bool DoesStaffExist(string staffId);
    }
    public interface IDisinfectionService
    {
        void AddRecord(disinfection_record record);
    }
}
