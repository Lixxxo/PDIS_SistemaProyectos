using System.IO;
using Microsoft.EntityFrameworkCore;
using SistemaProyectos.Model;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace SistemaProyectos.Database
{
    public class SystemDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string fileName = "C:\\Users\\Vicen\\Desktop\\Proyectos\\pdis\\Trabajo 2\\SistemaProyectos\\Database\\localdb.json";
            string jsonString = System.IO.File.ReadAllText(fileName);

            MSSQLConection connection = JsonSerializer.Deserialize<List<MSSQLConection>>(jsonString)[0];
            // Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
            ;
            var connectionString = new StringBuilder();

            if (connection.pass != "")
            {
                //Server=myServer;Database=myDatabase;Uid=myUser;Pwd=myPassword;
                connectionString.AppendFormat(
                    "Server={0};Database={1};User Id={2};Password={3};",
                    connection.host,
                    connection.dbName,
                    connection.user,
                    connection.pass);                
            }
            else
            {
                //Server=localhost\SQLEXPRESS;Database=master;TrustedConnection=True;
                connectionString.AppendFormat(
                    "Server={0};Database={1};TrustedConnection=True;",
                    connection.host,
                    connection.dbName);
            }


            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(connectionString.ToString(),
                    option =>
                    {
                    });
            }
        }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobMaterial> JobMaterials { get; set; }
        
    }

};
