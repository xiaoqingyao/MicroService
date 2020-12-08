using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MicroService.Linq2Sqls;
using MicroService.Models;
using MicroService.Models.Db;
using MicroService.Models.DTO;
using MicroService.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        SQLDbContext _dbContext;
        private readonly IMapper _mapper;
        public UsersController(SQLDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public bool Add(UserDTO userDTO)
        {
            var entity = _mapper.Map<UserEntity>(userDTO);
            _dbContext.Set<UserEntity>().Add(entity);
            return _dbContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="userQueryPatameters"></param>
        /// <returns></returns>
        [Route("List")]
        [HttpPost]
        public ReturnViewModel<UserViewModel> List(UserQueryPatameters userQueryPatameters)
        {
            var query = _dbContext.Set<UserEntity>().AsQueryable();
            if (string.IsNullOrEmpty(userQueryPatameters.Name))
            {
                query = query.Where(p => p.Name.Contains(userQueryPatameters.Name));
            }
            var count = query.Count();
            var rel = query.Skip((userQueryPatameters.PageIndex - 1) * userQueryPatameters.PageSize).Take(userQueryPatameters.PageSize).Select(p => new UserViewModel { Gid = p.Gid, Introduction = p.Introduction, Name = p.Name }).ToList();
            return new ReturnViewModel<UserViewModel>()
            {
                Records = rel,
                ReturnCode = EReturnCode.Success,
                TotalCount = count
            };
        }
        /// <summary>
        /// 获取用户列表-Get
        /// </summary>
        /// <returns></returns>
        [Route("GetList")]
        [HttpGet]
        public ReturnViewModel<UserViewModel> GetList()
        {
            var query = _dbContext.Set<UserEntity>().AsQueryable();

            var count = query.Count();
            var rel = query.Select(p => new UserViewModel { Gid = p.Gid, Introduction = p.Introduction, Name = p.Name }).ToList();
            Console.WriteLine("接口被调用了！");
            return new ReturnViewModel<UserViewModel>()
            {
                Records = rel,
                ReturnCode = EReturnCode.Success,
                TotalCount = count
            };
        }
        /// <summary>
        /// 获取用户列表-Get
        /// </summary>
        /// <returns></returns>
        [Route("GetUser")]
        [HttpGet]
        public UserViewModel GetUser(int id)
        {
            var query = _dbContext.Set<UserEntity>().AsQueryable().Where(p => p.EId == id);
            var count = query.Count();
            var rel = query.Select(p => new UserViewModel { Gid = p.Gid, Introduction = p.Introduction, Name = p.Name }).SingleOrDefault();
            rel.Name = HttpContext.Request.Host.Port.ToString();
            return rel;
        }

        [Route("GetList_ORM2")]
        [HttpGet]
        public ReturnViewModel<UserViewModel> GetList_ORM2()
        {
            //var query = _dbContext.Set<UserEntity>().AsQueryable();

            //var count = query.Count();
            //var rel = query.Select(p => new UserViewModel { Gid = p.Gid, Introduction = p.Introduction, Name = p.Name }).ToList();
            //Console.WriteLine("接口被调用了！");
            using (var db = new MicroServiceDB())
            {
                var query = from p in db.User
                            where p.EId > 0
                            orderby p.Name descending
                            select p;
                var rel = query.Select(p => new UserViewModel()
                {
                    Gid = p.Gid,
                    Introduction = p.Introduction,
                    Name = p.Name
                }).ToList();
                return new ReturnViewModel<UserViewModel>()
                {
                    Records = rel,
                    ReturnCode = EReturnCode.Success,
                    TotalCount = rel.Count
                };
            }

        }
    }
}
