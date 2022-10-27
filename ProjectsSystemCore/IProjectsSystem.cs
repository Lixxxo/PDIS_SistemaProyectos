using SistemaProyectos.Model;

namespace SistemaProyectos.ProjectsSystemCore;

public interface IProjectsSystem
{
    /// <summary>
    /// Create a Project into the database.
    /// </summary>
    /// <param name="project">The new project.</param>
    /// <returns>True if success.</returns>
    bool CreateProject(Project project);

    /// <summary>
    /// Create a Task (task) into the database.
    /// </summary>
    /// <param name="task">The new Task (task).</param>
    /// /// <param name="projectId">The project that is asociated with the task.</param>
    /// <returns></returns>
    bool CreateTask(Task task, int projectId);

    /// <summary>
    /// Modify an existent Task (task) from the database.
    /// </summary>
    /// <param name="projectId">The id of actual project.</param>
    /// <param name="updatedProject">The new Project with updated values.</param>
    /// <returns>True if success.</returns>
    bool ModifyProject(int projectId, Project updatedProject);
    
    /// <summary>
    /// Modify an existent Task (task) from the database.
    /// </summary>
    /// <param name="taskId">The id of the Task to modify.</param>
    /// <param name="updatedTask">The new Task with updated values.</param>
    /// <returns>True if success.</returns>
    bool ModifyTask(int taskId, Task updatedTask);

    /// <summary>
    /// Assign Task material to the given material.
    /// </summary>
    /// <param name="materialId">The id of the Material that is going the be assigned.</param>
    /// <param name="taskId">The id of the Task that is going the be assigned.</param>
    /// <returns>True if success.</returns>
    bool AssignMaterial(int materialId, int taskId);
}