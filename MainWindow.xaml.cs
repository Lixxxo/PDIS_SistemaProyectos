
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

        Project SelectedProject { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            SelectedProject = new Project();
            SelectedProject!.Id = 1;
            PopulateView();
        }

        private void BtnCreateProject_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new SystemDbContext())
            {
                var p = new Project();
                context.Projects.Add(p);
                context.SaveChanges();
            }
            PopulateView();
        }
        private void BtnCreateTask_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void PopulateView()
        {
            using (var context = new SystemDbContext())
            {
                ProjectList = context.Projects.ToList<Project>();

                if (ProjectList.Count != 0)
                {
                    int selectedId = this.SelectedProject.Id;
                    var resultsProjectTask = context.Tasks
                                                                .Where(t => t.Id == selectedId)
                                                                .ToList();
                    TaskList = context.Tasks.ToList<Task>();
                }


            }
            DgProjects.Columns.Clear();
            DgTasks.Columns.Clear();

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
            foreach (var task in TaskList!)
            {
                dtProject.Rows.Add(task.Id, task.Name, task.State, task.Progress);
            }

            DgProjects.ItemsSource = dtProject.DefaultView;
            DgTasks.ItemsSource = dtTask.DefaultView;
        }


    }
    
}
