using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace SistemaProyectos.Model
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name", TypeName = "ntext")]
        public string Name { get; set; }
        [Column("State", TypeName = "ntext")]
        public string State { get; set; }

        public Project()
        {
            this.Name = "Nuevo Proyecto";
            this.State = "Inactivo";
            this.Tasks = new List<Task>();
        }
        
        public ICollection<Task> Tasks { get; set; }

    }
}