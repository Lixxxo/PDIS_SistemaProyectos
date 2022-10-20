using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace SistemaProyectos.Model
{
    [Table("Materials")]
    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Name", TypeName = "ntext")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Column("Price")]
        public int Price { get; set; }
        
        public Material()
        {
        }

        public ICollection<TaskMaterial> TaskMaterials { get; set; }
        
    }
}