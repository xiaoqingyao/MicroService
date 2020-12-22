using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using MicroService.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Linq2Sqls
{
    public class MicroServiceDB : LinqToDB.Data.DataConnection
    {
        public MicroServiceDB() : base(GetOption())
        {
        }
        public ITable<CategoryEntity> Category => GetTable<CategoryEntity>();
        public ITable<UserEntity> User => GetTable<UserEntity>();
        public ITable<DepartmentEntity> Department => GetTable<DepartmentEntity>();
        public ITable<DesignEntity> Designs => GetTable<DesignEntity>();
        static LinqToDbConnectionOptions GetOption()
        {
            var builder = new LinqToDbConnectionOptionsBuilder();
            builder.UseSqlServer("Server=.;Database=d4l_main;User Id=sa;Password=Dbuser2015;");
            //MicroService
            return builder.Build();
        }
    }
}
