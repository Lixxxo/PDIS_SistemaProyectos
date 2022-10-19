using SistemaProyectos.Model;

namespace SistemaProyectos.ProjectsSystemCore;

public interface IProjectsSystem
{
    /// <summary>
    /// Create a project into the database.
    /// </summary>
    /// <param name="project">The new project.</param>
    /// <returns>True if success.</returns>
    bool CreateProject(Project project);

    /// <summary>
    /// Create a job (task) into the database.
    /// </summary>
    /// <param name="job">The new job (task).</param>
    /// <returns></returns>
    bool CreateJob(Job job);

    /// <summary>
    /// Modify an existent job (task) from the database.
    /// </summary>
    /// <param name="jobId">The id of the job to modify.</param>
    /// <param name="updatedJob">The new job with updated values.</param>
    /// <returns>True if success.</returns>
    bool ModifyJob(int jobId, Job updatedJob);

    /// <summary>
    /// Assign job material to the given material.
    /// </summary>
    /// <param name="material">The focus material.</param>
    /// <param name="jobMaterial">The job material that is going the assign.</param>
    /// <returns>True if success.</returns>
    bool AssignMaterial(Material material, JobMaterial jobMaterial);
}