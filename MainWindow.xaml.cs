
using System.Text.Json;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SistemaProyectos.Database;
using SistemaProyectos.Model;
using System.Data;

namespace SistemaProyectos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Project>? Project_List { get; set; }
        List<Job>? Job_List { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();

            btnCreateJob.IsEnabled = false;
            btnAsignMaterial.IsEnabled = false;
            PopulateView();
        }

        private void btnCreateProject_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new SystemDbContext())
            {
                var p = new Project();
                context.Projects.Add(p);
                context.SaveChanges();
            }
            PopulateView();


        }

        private void PopulateView()
        {
            dgProjects.Columns.Clear();
            dgJobs.Columns.Clear();
            using (var context = new SystemDbContext())
            {
                Project_List = context.Projects.ToList<Project>();
                Job_List = context.Jobs.ToList<Job>();

            }
            DataTable dtProject = new DataTable();
            dtProject.Columns.Add("Id");
            dtProject.Columns.Add("Nombre");
            dtProject.Columns.Add("Estado");

            DataTable dtJob = new DataTable();
            dtJob.Columns.Add("Id");
            dtJob.Columns.Add("Nombre");
            dtJob.Columns.Add("Estado");
            dtJob.Columns.Add("Progreso");

            foreach (var project in Project_List)
            {

                dtProject.Rows.Add(project.Id, project.Name, project.State);

            }
            foreach (var job in Job_List)
            {
                dtProject.Rows.Add(job.Id, job.Name, job.State, job.Progress);
            }

            dgProjects.ItemsSource = dtProject.DefaultView;
            dgJobs.ItemsSource = dtJob.DefaultView;
        }
    }
    
}
