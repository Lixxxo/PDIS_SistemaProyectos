
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using SistemaProyectos.Database;
using SistemaProyectos.Model;


namespace SistemaProyectos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        List<Project>? ProjectList { get; set; }
        List<Task>? TaskList { get; set; }
        
        List<Material>? MaterialList { get; set; }
        
        List<TaskMaterial>? TaskMaterialList { get; set; }
        Project? SelectedProject { get; set; }
        Task? SelectedTask { get; set; }
        
        Material? SelectedMaterial { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            Console.Out.Write("XD");
            BtnCreateTask.IsEnabled = false;
            BtnAssignMaterial.IsEnabled = false;
            StackMaterials.IsEnabled = false;
            PopulateView();
        }

        private void BtnCreateProject_Click(object sender, RoutedEventArgs e)
        {
            var p = new Project();
            using (var context = new SystemDbContext())
            {
                context.Projects.Add(p);
                context.SaveChanges();
                SelectedProject = p;
            }
            PopulateView();
            if (ProjectList != null) SelectedProject = ProjectList.Last();
            // Move Focus
            var lastProjectIndex = DgProjects.Items.Count - 1;
            DgProjects.SelectedIndex = lastProjectIndex;
            
            DgProjects.UpdateLayout();
            DgProjects.ScrollIntoView(DgProjects.Items[lastProjectIndex]);
            SelectedProject = (ProjectList ?? throw new InvalidOperationException()).Last();
        }
        
        private void BtnCreateTask_Click(object sender, RoutedEventArgs e)
        {
            var t = new Task();
            using (var context = new SystemDbContext())
            {
                var selectedId = SelectedProject?.Id ?? 0;
                Project p = context.Projects.Find(selectedId)!;

                p.Tasks.Add(t);
                context.Tasks.Add(t);
                context.SaveChanges();
                SelectedProject = p;
            }
            
            PopulateView();

            if (TaskList != null) SelectedTask = TaskList.Last();
            // Move Focus
            var lastTaskIndex = DgTasks.Items.Count - 1;
            DgTasks.SelectedIndex = lastTaskIndex;
            
            DgTasks.UpdateLayout();
            DgTasks.ScrollIntoView(DgTasks.Items[lastTaskIndex]);
            SelectedTask = (TaskList ?? throw new InvalidOperationException()).Last();

        }

        private void PopulateView()
        
        {   
            // Querying from database.
            using (var context = new SystemDbContext())
            {
                MaterialList = context.Materials.ToList();
                ProjectList = context.Projects.ToList();
                if (SelectedProject != null)
                {
                    TaskList = context.Tasks
                                        .Where(t => t.ProjectId == SelectedProject.Id)
                                        .ToList();
                }
                else
                {
                    TaskList = new List<Task>();
                }
            }
            BtnCreateTask.IsEnabled = ProjectList.Count != 0;

            // Update DataGrids
            DgProjects.ItemsSource = null;
            DgTasks.ItemsSource = null;
            DgMaterials.ItemsSource = null;
            
            DgProjects.ItemsSource = ProjectList.ToList();
            DgTasks.ItemsSource = TaskList.ToList();
            DgMaterials.ItemsSource = MaterialList.ToList();

            
        }

        private void DgProjects_Selected(object sender, RoutedEventArgs routedEventArgs)
        {
            DataGridRow? dgr = sender as DataGridRow;
            dgr!.IsSelected = true;
            SelectedProject = (Project?)dgr.Item;

            using (var context = new SystemDbContext())
            {
                TaskList = context.Tasks
                    .Where(t => t.ProjectId == SelectedProject!.Id)
                    .ToList();
            }
            DgTasks.ItemsSource = null;
            DgTasks.ItemsSource = TaskList;
        }

        private void DgTasks_Selected(object sender, RoutedEventArgs routedEventArgs)
        {
            DataGridRow? dgr = sender as DataGridRow;
            dgr!.IsSelected = true;
            SelectedTask = (Task?)dgr.Item;

            StackMaterials.IsEnabled = true;
            BtnAssignMaterial.IsEnabled = true;

        }
        private void BtnAssignMaterial_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DgMaterials_Selected(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DgTaskMaterials_Selected(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        
    }
    
}
