using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace SistemaProyectos.Model
{
    [Table("Tasks")]
    public class Task
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

        public Task()
        {
            this.Name = "Nueva Tarea";
            this.State = "Inactivo";
            this.Progress = 0.0f;
            this.TaskMaterials = new List<TaskMaterial>();
        }
        public virtual Project Project {get; set;}
        public ICollection<TaskMaterial> TaskMaterials { get; set; }

        public string ProgressString
        {
            get
            {
                const int total = 20;
                var progressBarText = "";
                progressBarText += this.Progress.ToString("0.00") + "->[";

                var decimalPart = this.Progress * 100 % 100;

                var completedBars = (int)decimalPart / total / 4;

                for (var i = 0; i < total; i++)
                {
                    if (completedBars == 0 && this.Progress > 0)
                    {
                        for (var j = 0; j < total; j++)
                        {
                            progressBarText += "=";
                        }

                        break;
                    }

                    if (i < completedBars) progressBarText += "=";
                    else progressBarText += "-";
                }

                progressBarText += "]";
                return progressBarText;
            }
        }
    }
}