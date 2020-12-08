using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using l2db = LinqToDB.Mapping;

namespace MicroService.Models.Db
{
    /// <summary>
    /// 用户数据库实体
    /// </summary>
    [Table(name: "Users")]
    public class UserEntity
    {
        /// <summary>
        /// 自增Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [l2db.Column]
        public int EId { get; set; }
        [l2db.Column]
        public DateTime CreationTime { get; set; } = DateTime.Now;
        [l2db.Column]
        public DateTime UpdatTime { get; set; } = DateTime.Now;
        [l2db.Column]
        public Guid Gid { get; set; }
        [l2db.Column]
        public bool Deleted { get; set; }
        [l2db.Column]
        public string Name { get; set; }
        [l2db.Column]
        public string Pwd { get; set; }
        //public string Email { get; set; }
        public DateTime RegistTime { get; set; }
        [l2db.Column]
        public DateTime LastLoginTime { get; set; }
        [l2db.Column]
        public bool Status { get; set; } = true;
        [l2db.Column]
        public string Introduction { get; set; }
    }
}
