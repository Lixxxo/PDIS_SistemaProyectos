using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Data;
using Windows.Foundation.Metadata;

namespace SistemaProyectos.Model
{
    [Table("JobMaterials")]
    public class JobMaterial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Hour", TypeName = "datetime")]
        public DateTime? Hour { get; set; }

        [Column("Amount", TypeName = "int")]
        public int Amount { get; set; }

        public JobMaterial()
        {
            Hour = DateTime.Now;
            Amount = 0;
        }


    }
}

