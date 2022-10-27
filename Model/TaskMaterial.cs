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
        [Column("Date", TypeName = "Date")]
        public DateTime? Date { get; set; }
        [Column("Quantity", TypeName = "int")]
        public int Quantity { get; set; }

        public int TaskId { get; set; }
        public int MaterialId { get; set; }


        public TaskMaterial()
        {
            this.Date = DateTime.Today;
            
            this.Quantity = 0;
        }

    }
}

