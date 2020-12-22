using MicroService.Filters;
using MicroService.Linq2Sqls;
using MicroService.Models.Db;
using MicroService.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : Controller
    {
        SQLDbContext _dbContext;
        public BlockController(SQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        [Route("Error")]
        public ReturnViewModel<DesignEntity> Error()
        {
            using (var db = new MicroServiceDB())
            {
                var query = from p in db.Designs
                            where p.Name.Contains("6")
                            orderby p.Name descending
                            select p;
                try
                {
                    var rel = query.Select(p => new DesignEntity()
                    {
                        Gid = p.Gid,
                        Name = p.Name
                    }).ToList();
                }
                catch  
                { 
                }
               
                //var count = query.Count();
                return new ReturnViewModel<DesignEntity>()
                {
                    Records = null,
                    ReturnCode = EReturnCode.Success,
                    TotalCount = 0,
                    //ReturnMessage = $"共耗时：{(sw.ElapsedMilliseconds / 1000)}秒"
                };
            }
        }

        [HttpPost]
        [Route("Normal")]
        public ReturnViewModel<DesignEntity> Normal()
        {
            using (var db = new MicroServiceDB())
            {
                var query = from p in db.Designs
                            where p.Name == "666"
                            orderby p.Name descending
                            select p;
                List<DesignEntity> rel = new List<DesignEntity>();
                try
                {
                     rel = query.Select(p => new DesignEntity()
                    {
                        Gid =  p.Gid,
                        Name = p.Name
                    }).ToList();
                }
                catch {                   
                }
                
                //var count = query.Count();
                return new ReturnViewModel<DesignEntity>()
                {
                    Records = rel,
                    ReturnCode = EReturnCode.Success,
                    TotalCount = rel.Count,
                    //ReturnMessage = $"共耗时：{(sw.ElapsedMilliseconds / 1000)}秒"
                };
            }
        }

    }
}
