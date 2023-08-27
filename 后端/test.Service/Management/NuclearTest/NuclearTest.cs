using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using test.Common.Db;
using test.Module.Entities;

namespace test.Service.Management.NuclearTest
{
    public class NuclearTest
    {
        private readonly IMapper _mapper;
        public NuclearTest(IMapper mapper)
        {
            _mapper = mapper;
        }
        public nuclear_test_info Insert(nuclear_test_info_dto input)
        {
            string exp = Check(input);
            if (exp == String.Empty)
            {
                nuclear_test_info test = TransInputDto(input);
                DbContext.db.Insertable(test).IgnoreColumns("test_result").ExecuteCommand();
                return test;
            }
            else
                throw new Exception(exp);
        }
        private nuclear_test_info TransInputDto(nuclear_test_info_dto input)
        {
            var test = _mapper.Map<nuclear_test_info>(input);
            test.test_time = DateTime.Now.ToString("G");
            return test;
        }
        private nuclear_test_info TransInputDto(nuclear_detection_dto input)
        {
            var test=_mapper.Map<nuclear_test_info>(input);
            return test;
        }
        private string Check(nuclear_test_info_dto input)
        {
            if(CheckUID(input.user_id)!=String.Empty)
            {
                return "用户不存在";
            }
            if(CheckPID(input.test_tube_ID)!=String.Empty)
            {
                return "此试管不存在";
            }
            return String.Empty;
        }
        private string CheckUID(string input)
        {
            if (!DbContext.db.Queryable<userinfo>().Any(m => m.id.Equals(input)))
            {
                return "用户不存在";
            }
            return String.Empty;
        }
        private string CheckPID(string input)
        {
            if (!DbContext.db.Queryable<nuclear_pipe_info>().Any(m => m.test_tube_ID.Equals(input)))
            {
                return "此试管不存在";
            }
            return String.Empty;
        }
        public string UpdateDetectionResult(nuclear_detection_dto input)
        {
            string exp=CheckPID(input.test_tube_ID);
            nuclear_test_info test = TransInputDto(input);
            if (exp != String.Empty)
                throw new Exception(exp);
            else
            {
                DbContext.db.Updateable(test).UpdateColumns(it => new { it.test_result }).ExecuteCommand();
                return String.Empty;
            }
        }
    }
}
