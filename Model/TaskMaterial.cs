using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;


namespace SistemaProyectos.Model
{
    [Table("TaskMaterials")]
    public class TaskMaterial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Hour", TypeName = "datetime")]
        public DateTime? Hour { get; set; }
        [Column("Quantity", TypeName = "int")]
        public int Quantity { get; set; }

        public TaskMaterial()
        {
            this.Hour = DateTime.Now;
            this.Quantity = 0;
        }

    }
}

