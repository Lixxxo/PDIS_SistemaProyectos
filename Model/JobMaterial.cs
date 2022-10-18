using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;


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
        [Column("Quantity", TypeName = "int")]
        public int Quantity { get; set; }

        public JobMaterial()
        {
            Hour = DateTime.Now;
            Quantity = 0;
        }

    }
}

