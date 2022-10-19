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
    /// List of jobs.
    /// </summary>
    private List<Job> _jobs;

    /// <summary>
    /// List of projects.
    /// </summary>
    private List<Project> _projects;

    /// <summary>
    /// Constructor of the system.
    /// </summary>
    public ProjectsSystem()
    {
        _jobs = new List<Job>();
        _projects = new List<Project>();
    }

    public bool CreateProject(Project project)
    {
        throw new NotImplementedException();
    }

    public bool CreateJob(Job job)
    {
        throw new NotImplementedException();
    }

    public bool ModifyJob(int jobId, Job updatedJob)
    {
        throw new NotImplementedException();
    }

    public bool AssignMaterial(Material material, JobMaterial jobMaterial)
    {
        throw new NotImplementedException();
    }
}