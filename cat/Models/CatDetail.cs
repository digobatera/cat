using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cat.Models
{
    public class CatDetail
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string origem { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string temperamento { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string descricao { get; set; }
    }
}
