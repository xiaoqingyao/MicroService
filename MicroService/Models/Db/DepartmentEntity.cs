using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Models.Db
{
    public class DepartmentEntity
    {
        /// <summary>
        /// 自增Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EId { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime UpdatTime { get; set; } = DateTime.Now;
        public Guid Gid { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
    }
}
