
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using SistemaProyectos.Database;
using SistemaProyectos.Model;
using SistemaProyectos.ProjectsSystemCore;


namespace SistemaProyectos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ProjectsSystem ProjectSystem;
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
            ProjectSystem = new ProjectsSystem();
        }

        private void BtnCreateProject_Click(object sender, RoutedEventArgs e)
        {
            var p = new Project();
            if (!ProjectSystem.CreateProject(p)) return;
            
            SelectedProject = p;
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
            
            if(SelectedProject != null && !ProjectSystem.CreateTask(t, SelectedProject.Id)) return;
            
            PopulateView();

            if (TaskList != null) SelectedTask = TaskList.Last();
            // Move Focus
            var lastTaskIndex = DgTasks.Items.Count - 1;
            DgTasks.SelectedIndex = lastTaskIndex;
            
            DgTasks.UpdateLayout();
            DgTasks.ScrollIntoView(DgTasks.Items[lastTaskIndex]);
            SelectedTask = (TaskList ?? throw new InvalidOperationException()).Last();

        }
        private void BtnUpdateProject_Click(object sender, RoutedEventArgs e)
        {
            Project newProject = (Project) DgProjects.SelectedItem;
            if (SelectedProject != null && !ProjectSystem.ModifyProject(SelectedProject.Id, newProject)) return;
            PopulateView();
        }
        private void BtnUpdateTask_Click(object sender, RoutedEventArgs e)
        {
            Task newTask = (Task) DgTasks.SelectedItem;
            if (SelectedTask != null && !ProjectSystem.ModifyTask(SelectedTask.Id, newTask)) return;
            PopulateView();
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

                RefreshTaskMaterialGrid();
            }
            
            // Buttons enabling
            RefreshEnabled();

            // Update DataGrids
            DgProjects.ItemsSource = null;
            DgTasks.ItemsSource = null;
            DgMaterials.ItemsSource = null;
            
            
            DgProjects.ItemsSource = ProjectList.ToList();
            DgTasks.ItemsSource = TaskList.ToList();
            DgMaterials.ItemsSource = MaterialList.ToList();
            


        }

        public void RefreshTaskMaterialGrid()
        {

            if (SelectedMaterial != null && SelectedTask != null)
            {
                using (var context = new SystemDbContext())
                {
                    TaskMaterialList = context.TaskMaterials
                        .Where(tm => tm.MaterialId == SelectedMaterial.Id && tm.TaskId == SelectedTask.Id)
                        .ToList();    
                }
            }
            else
            {
                TaskMaterialList = new List<TaskMaterial>();
            }
            DgTaskMaterials.ItemsSource = null;
            DgTaskMaterials.ItemsSource = TaskMaterialList.ToList();
        }
        public void RefreshEnabled()
        {
            
            BtnUpdateProject.IsEnabled = SelectedProject != null;
            BtnCreateTask.IsEnabled = SelectedProject != null;
            BtnUpdateTask.IsEnabled = SelectedProject != null && SelectedTask != null;
            
            StackMaterials.IsEnabled = SelectedProject != null && SelectedTask != null;
            BtnAssignMaterial.IsEnabled = SelectedMaterial != null && SelectedTask !=null;
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

            SelectedTask = null;
            SelectedMaterial = null;
            
            RefreshEnabled();
        }

        private void DgTasks_Selected(object sender, RoutedEventArgs routedEventArgs)
        {
            DataGridRow? dgr = sender as DataGridRow;
            dgr!.IsSelected = true;
            SelectedTask = (Task?)dgr.Item;
            
            RefreshEnabled();
            RefreshTaskMaterialGrid();

        }
        private void BtnAssignMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTask != null && SelectedMaterial != null)
                ProjectSystem.AssignMaterial(SelectedMaterial.Id, SelectedTask.Id);
            PopulateView();
        }

        private void DgMaterials_Selected(object sender, RoutedEventArgs e)
        {
            DataGridRow? dgr = sender as DataGridRow;
            dgr!.IsSelected = true;
            SelectedMaterial = (Material?)dgr.Item;
            RefreshEnabled();
            RefreshTaskMaterialGrid();
        }
        
    }
    
}
