
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
using System.Data.Entity.Core.Objects;

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

            PopulateView();
        }

        private void BtnCreateProject_Click(object sender, RoutedEventArgs e)
        {
            var p = new Project();
            using (var context = new SystemDbContext())
            {
                context.Projects.Add(p);
                context.SaveChanges();
            }
            PopulateView();
        }
        private void BtnCreateTask_Click(object sender, RoutedEventArgs e)
        {
            var t = new Task
            {
                Project = SelectedProject
            };
            using (var context = new SystemDbContext())
            {
                context.Tasks.Add(t);
                context.SaveChanges();
            }
            //

        }

        private void PopulateView()
        {
            using (var context = new SystemDbContext())
            {
                this.ProjectList = context.Projects.ToList<Project>();

                if (ProjectList.Count != 0)
                {
                    this.SelectedProject = ProjectList.First();
                    this.TaskList = this.SelectedProject.Tasks.ToList<Task>();
                }


            }
            DgProjects.ItemsSource = null;
            DgTasks.ItemsSource = null;
            
            DgProjects.ItemsSource = this.ProjectList.ToList();
            DgTasks.ItemsSource = this.TaskList.ToList();

        }

    }
    
}
