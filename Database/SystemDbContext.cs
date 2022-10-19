using Microsoft.EntityFrameworkCore;
using SistemaProyectos.Model;

namespace SistemaProyectos.Database;

/// <summary>
/// Core of the database.
/// </summary>
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

    #region ENTITIES
    
    public virtual DbSet<Material> Materials { get; set; }
    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<Job> Jobs { get; set; }
    public virtual DbSet<JobMaterial> JobMaterials { get; set; }
    public virtual DbSet<Movement> Movements { get; set; }

    #endregion
}