using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;


namespace SistemaProyectos.Model
{
    [Table("Movement")]
    public class Movement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Type", TypeName = "ntext")]
        [MaxLength(20)]
        public string Type { get; set; }
        [Column("Quantity")]
        public int Quantity { get; set; }
        [Column("Hour", TypeName = "datetime")]
        public DateTime? Hour { get; set; }
        
        public Movement()
        {
            Quantity = 0;
            Hour = DateTime.Now;
        }

        public ICollection<Material> Materials { get; set; }
        
    }
}