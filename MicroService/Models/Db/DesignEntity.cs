using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using l2db = LinqToDB.Mapping;

namespace MicroService.Models.Db
{
    [System.ComponentModel.DataAnnotations.Schema.Table(name: "Desgins")]
    public class DesignEntity
    {
        /// <summary>
        /// 自增Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [l2db.Column]
        public int EId { get; set; }
 
        [l2db.Column]
        public Guid Gid { get; set; }
        [l2db.Column]
        public bool Deleted { get; set; }
        [l2db.Column]
        public string Name { get; set; }
    }
}
