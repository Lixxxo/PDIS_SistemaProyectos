
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
using System.Windows.Input;

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
        Task SelectedTask { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            BtnCreateTask.IsEnabled = false;
            BtnAssignMaterial.IsEnabled = false;
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

            this.SelectedProject = p;
            PopulateView();

        }
        
        private void BtnCreateTask_Click(object sender, RoutedEventArgs e)
        {
            var t = new Task();
            using (var context = new SystemDbContext())
            {
                Project p = context.Projects.Find(SelectedProject.Id)!;
                p.Tasks.Add(t);
                context.Tasks.Add(t);
                context.SaveChanges();
                this.SelectedProject = p;
            }
            
            PopulateView();

        }

        private void PopulateView()
        {   
            // Querying from database.
            using (var context = new SystemDbContext())
            {
                this.ProjectList = context.Projects.ToList<Project>();
                if (SelectedProject != null)
                {
                    this.TaskList = this.SelectedProject.Tasks.ToList<Task>();
                }
                else
                {
                    this.TaskList = new List<Task>();     
                }

            }
            
            if (this.ProjectList.Count != 0)
            {
                BtnCreateTask.IsEnabled = true;
                this.SelectedProject = ProjectList.Last();

                if (this.TaskList.Count != 0)
                {
                    this.SelectedTask = TaskList.First();
                    BtnAssignMaterial.IsEnabled = true;
                }
                else
                {
                    BtnAssignMaterial.IsEnabled = false;
                }
            }
            else
            { 
                BtnCreateTask.IsEnabled = false;
            }
            
            // Update DataGrids
            DgProjects.ItemsSource = null;
            DgTasks.ItemsSource = null;
            
            DgProjects.ItemsSource = this.ProjectList.ToList();
            DgTasks.ItemsSource = this.TaskList.ToList();
            
            // Move Focus
            var lastProjectIndex = DgProjects.Items.Count - 1;
            DgProjects.SelectedIndex = lastProjectIndex;
            
            DgProjects.UpdateLayout();
            DgProjects.ScrollIntoView(DgProjects.Items[lastProjectIndex]);
            BtnAssignMaterial.Content = this.SelectedProject.Id;
            /**
            var firstTaskIndex = 0;
            DgTasks.SelectedIndex = firstTaskIndex;
            
            DgTasks.UpdateLayout();
            DgTasks.ScrollIntoView(DgTasks.Items[firstTaskIndex]);
            */
            BtnAssignMaterial.Content = this.SelectedProject.Id + " " ;



        }

    }
    
}
