using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using test.Common.Db;
using test.Module.Entities;

namespace test.Service.Management.NuclearPipe
{
    public class NuclearPipe
    {
        private readonly IMapper _mapper;
        public NuclearPipe(IMapper mapper)
        {
            _mapper = mapper;
        }
        public nuclear_pipe_info Insert(nuclear_pipe_info_dto info)
        {
            nuclear_pipe_info pipe = TransInputDto(info);
            if (!DbContext.db.Queryable<nuclear_pipe_info>().Any(m => m.test_tube_ID.Equals(pipe.test_tube_ID)))
            {
                DbContext.db.Insertable(pipe).ExecuteCommand();
                return pipe;
            }
            else
                throw new Exception("当前试管已存在");
        }
        private nuclear_pipe_info TransInputDto(nuclear_pipe_info_dto input)
        {
            var pipe = _mapper.Map<nuclear_pipe_info>(input);
            pipe.test_time = DateTime.Now.ToString("G");
            return pipe;
        }
    }
}
