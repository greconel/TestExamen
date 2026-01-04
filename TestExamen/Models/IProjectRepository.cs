using System.Net.Http.Headers;

namespace TestExamen.Models
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjectsAsync();
        Task<Project?> GetProjectAsync(int id);
        Task AddProjectAsync(Project project);
        Task DeleteProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);

        bool ProjectExists(int id);
    }
}
