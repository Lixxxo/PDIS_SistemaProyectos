using System;
using System.Collections.Generic;
using SistemaProyectos.Model;
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
    private List<Task> _Tasks;

    /// <summary>
    /// List of projects.
    /// </summary>
    private List<Project> _projects;

    /// <summary>
    /// Constructor of the system.
    /// </summary>
    public ProjectsSystem()
    {
        _Tasks = new List<Task>();
        _projects = new List<Project>();
    }

    public bool CreateProject(Project project)
    {
        throw new NotImplementedException();
    }

    public bool CreateTask(Task Task)
    {
        throw new NotImplementedException();
    }

    public bool ModifyTask(int TaskId, Task updatedTask)
    {
        throw new NotImplementedException();
    }

    public bool AssignMaterial(Material material, TaskMaterial TaskMaterial)
    {
        throw new NotImplementedException();
    }
}