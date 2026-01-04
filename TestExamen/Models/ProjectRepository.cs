
using Microsoft.EntityFrameworkCore;

namespace TestExamen.Models
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectContext _context;

        public ProjectRepository(ProjectContext context)
        {
            _context = context;
        }
        public async Task AddProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task<Project?> GetProjectAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.Student)
                .FirstOrDefaultAsync(p => p.ProjectId == id);
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            return await _context.Projects.Include(p => p.Student).ToListAsync();
        }

        public bool ProjectExists(int id)
        {
            return _context.Projects.Any(p => p.ProjectId == id);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}
