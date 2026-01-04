
using Microsoft.EntityFrameworkCore;

namespace TestExamen.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ProjectContext _context;

        public StudentRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
