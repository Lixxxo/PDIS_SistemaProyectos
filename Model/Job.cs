using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace SistemaProyectos.Model
{
    [Table("Jobs")]
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Name", TypeName = "ntext")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Column("State", TypeName = "ntext")]
        [MaxLength(20)]
        public string State { get; set; }
        [Column("Progress", TypeName = "float")]
        public float Progress { get; set; }

        public Job()
        {
            State = "Inactive";
            Progress = 0.0f;
        }

        public ICollection<JobMaterial> JobMaterials { get; set; }

    }
}