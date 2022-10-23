using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SistemaProyectos.Model;
using SistemaProyectos.Database;
using NotImplementedException = System.NotImplementedException;

namespace SistemaProyectos.ProjectsSystemCore;

/// <summary>
/// System to administrate projects database.
/// </summary>
public class ProjectsSystem : IProjectsSystem
{
    /// <summary>
    /// List of Tasks.
    /// </summary>
    private List<Task> _tasks;

    /// <summary>
    /// List of projects.
    /// </summary>
    private List<Project> _projects;

    /// <summary>
    /// Constructor of the system.
    /// </summary>
    public ProjectsSystem()
    {
        _tasks = new List<Task>();
        _projects = new List<Project>();
    }

    public bool CreateProject(Project project)
    {
        try
        {
            using (var context = new SystemDbContext())
            {
                context.Projects.Add(project);
                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }

        return true;

    }

    public bool CreateTask(Task task)
    {
        try
        {
            using (var context = new SystemDbContext())
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }

        return true;
    }

    public bool ModifyTask(int taskId, Task updatedTask)
    {
        try
        {
            using (var context = new SystemDbContext())
            {
                Task result = context.Tasks.First(t => t.Id == taskId);

                result.Name = updatedTask.Name;
                result.Progress = updatedTask.Progress;
                result.State = updatedTask.State;
                
                context.Entry(result).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }

        return true;
    }

    public bool AssignMaterial(Material material, TaskMaterial taskMaterial)
    {
        throw new NotImplementedException();
    }
}