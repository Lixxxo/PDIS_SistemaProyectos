
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

        List<Project>? ProjectList { get; set; }
        List<Task>? TaskList { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();

            btnCreateTask.IsEnabled = false;
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
            dgTasks.Columns.Clear();
            using (var context = new SystemDbContext())
            {
                ProjectList = context.Projects.ToList<Project>();
                TaskList = context.Tasks.ToList<Task>();

            }
            DataTable dtProject = new DataTable();
            dtProject.Columns.Add("Id");
            dtProject.Columns.Add("Nombre");
            dtProject.Columns.Add("Estado");

            DataTable dtTask = new DataTable();
            dtTask.Columns.Add("Id");
            dtTask.Columns.Add("Nombre");
            dtTask.Columns.Add("Estado");
            dtTask.Columns.Add("Progreso");

            foreach (var project in ProjectList)
            {

                dtProject.Rows.Add(project.Id, project.Name, project.State);

            }
            foreach (var Task in TaskList)
            {
                dtProject.Rows.Add(Task.Id, Task.Name, Task.State, Task.Progress);
            }

            dgProjects.ItemsSource = dtProject.DefaultView;
            dgTasks.ItemsSource = dtTask.DefaultView;
        }
    }
    
}
