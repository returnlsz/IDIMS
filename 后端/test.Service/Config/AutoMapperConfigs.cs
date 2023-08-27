using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using test.Module.Entities;
using test.Service.Management.NuclearPipe;
using test.Service.Management.NuclearTest;
using test.Service.User.Dto;

namespace test.Service.Config
{
    public class AutoMapperConfigs : Profile
    {
        public AutoMapperConfigs()
        {
            CreateMap<Users, UserDto>();
            CreateMap<InputUserDto, Users>();
            CreateMap<nuclear_pipe_info_dto, nuclear_pipe_info>();

            //核酸检测映射
            CreateMap<nuclear_test_info_dto, nuclear_test_info>();
            CreateMap<nuclear_detection_dto, nuclear_test_info>();
        }
    }
}
