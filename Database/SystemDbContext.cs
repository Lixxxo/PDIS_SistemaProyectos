using Microsoft.EntityFrameworkCore;
using SistemaProyectos.Model;

namespace SistemaProyectos.Database
{
    public class SystemDbContext : DbContext
    { 
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(DatabasePath.databasePath, 
                    option => {});
            }
        }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskMaterial> TaskMaterials { get; set; }
        
    }
}