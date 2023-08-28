using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SqlSugar;
using test.Common.Db;
using test.Module.Entities;
using test.Service.User.Dto;

namespace test.Service.User
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Users> CheckLogin(LoginDto login)
        {
            return await DbContext.db.Queryable<Users>().FirstAsync(m => m.id.Equals(login.id) && m.pwd.Equals(login.pwd));
        }
        public UserDto AddUser(InputUserDto input)
        {
            Users user = TransInputDto(input);
            if (!DbContext.db.Queryable<Users>().Any(m => m.id.Equals(input.id)))
            {
                DbContext.db.Insertable(user).ExecuteCommand();
                return _mapper.Map<UserDto>(user);
            }
            else
                throw new Exception("id已存在");
        }
        private Users TransInputDto(InputUserDto input)
        {
            var user = _mapper.Map<Users>(input);
            return user;
        }
        /// <summary>
        /// 用户上传抗原的数据库操作
        /// </summary>
        /// <param name="id"></param>
        /// <param name="test_time"></param>
        /// <param name="test_result"></param>
        /// <returns></returns>
        public int CheckAndUploadantigen(string id, DateTime test_time, string test_result)
        {
            ///数据库写入操作
            ///
            antigen_record antigen_Record = new antigen_record() {
                user_id = id,
                test_time = test_time,
                test_result = test_result
            };
            ///返回受影响条数
            return DbContext.db.Insertable(antigen_Record).ExecuteCommand();
        }
        /// <summary>
        /// 用户举报的数据库操作
        /// </summary>
        /// <returns></returns>
        public int UserPutReport(DateTime time,string id,string content)
        {
            ///先获取report表最后一行message_id的值（最新值）
            List<string> newest = (List<string>)DbContext.db.Queryable<report_info>().Select(it => it.message_id).ToList();
            string max = newest.OrderByDescending(x => x).First();
            int maxint=int.Parse(max);
            maxint++;
            max=maxint.ToString();
            report_info report_Info = new report_info()
            {
                time = time,
                user_id = id,
                state = 0,
                message_id = max,
                content = content
            };
            ///返回受影响条数
            return DbContext.db.Insertable(report_Info).ExecuteCommand();
        }
        /// <summary>
        /// 用户上传行程的数据库操作
        /// </summary>
        /// <returns></returns>
        public int UserUploadRouting(string id,string pos_id,DateTime time)
        {
            user_itinerary user_Itinerary = new user_itinerary()
            {
                id = id,
                pos_id = pos_id,
                time = time
            };
             
            ///返回受影响条数
            return DbContext.db.Insertable(user_Itinerary).ExecuteCommand();
        }
        /// <summary>
        /// 根据pos_id返回地区信息
        /// </summary>
        /// <param name="pos_id"></param>
        /// <returns></returns>
        public List<regioninfo> PosIdGetLocation(string pos_id)
        {
            List<regioninfo> Regioninfo= DbContext.db.Queryable<regioninfo>()
                        .Where(it => it.pos_id == pos_id).ToList();
            return Regioninfo;
        }
        /// <summary>
        /// 返回用户的健康信息表的数据库查询操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<user_health_state> GetUserHealthInfo(string id)
        {
            List<user_health_state> user_Health_state = DbContext.db.Queryable<user_health_state>()
                        .Where(it => it.id == id).ToList();
            return user_Health_state;
        }
    }
}
