using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace MicroService.Models.Db
{
    public class CategoryEntity
    {
        [PrimaryKey, Identity]
        public int Eid { get; set; }
        [Column(Name = "Gid"), NotNull]
        public Guid Gid { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
