using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Module.Entities;
using test.Service.Management.DisinfectionRecord;

namespace test.Service.Management.DisinfectionRecord
{
    public class ServiceSolution : IStaffService, IDisinfectionService
    {
        public void AddRecord(disinfection_record record)
        {
            throw new NotImplementedException();
        }

        public bool DoesStaffExist(string staffId)
        {
            throw new NotImplementedException();
        }
    }
}
