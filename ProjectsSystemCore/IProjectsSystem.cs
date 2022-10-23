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
    /// <returns></returns>
    bool CreateTask(Task task);

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
    /// <param name="material">The focus material.</param>
    /// <param name="taskMaterial">The Task material that is going the assign.</param>
    /// <returns>True if success.</returns>
    bool AssignMaterial(Material material, TaskMaterial taskMaterial);
}