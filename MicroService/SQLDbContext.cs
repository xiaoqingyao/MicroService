using MicroService.Models;
using MicroService.Models.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService
{
    public class SQLDbContext : DbContext
    {
        public DbSet<UserEntity> userInfo;
        /// <summary>
        /// 注意要实现该构造
        /// </summary>
        /// <param name="dbContext"></param>
        public SQLDbContext(DbContextOptions<SQLDbContext> dbContext) : base(dbContext)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(u =>
            {
                //设置表映射
                u.ToTable("Users");
                //设置索引
                u.HasIndex(u => new
                {
                    u.Name,
                    u.Status
                });
            });
            modelBuilder.Entity<DepartmentEntity>(u =>
            {
                //设置表映射
                u.ToTable("Departments");
                //设置索引
                u.HasIndex(u => new
                {
                    u.Name
                });
            });
        }
    }
}
