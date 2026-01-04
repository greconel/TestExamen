using Microsoft.EntityFrameworkCore;

namespace TestExamen.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    StudentName = "Van Damme, Lisa"
                },
                new Student
                {
                    StudentId = 2,
                    StudentName = "Janssens, Thomas"
                },
                new Student
                {
                    StudentId = 3,
                    StudentName = "Peeters, Emma"
                }
                
            );
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectId = 1,
                    StudentId = 1,
                    SubmissionDate = new DateTime(2024, 06, 18, 0, 0, 0),
                    TheoryScore = 16.5m,
                    PracticalScore = 14.0m,
                    PresentationScore = 3.8m,
                    TotalGrade = 34.3m
                },
                new Project
                {
                    ProjectId = 2,
                    StudentId = 2,
                    SubmissionDate = new DateTime(2024, 06, 18, 0, 0, 0),
                    TheoryScore = 18m,
                    PracticalScore = 16.5m,
                    PresentationScore = 4.5m,
                    TotalGrade = 39m
                },
                new Project
                {
                    ProjectId = 3,
                    StudentId = 3,
                    SubmissionDate = new DateTime(2024, 06, 18, 0, 0, 0),
                    TheoryScore = 14.5m,
                    PracticalScore = 13.0m,
                    PresentationScore = 3.2m,
                    TotalGrade = 4.0m
                },
                new Project
                {
                    ProjectId = 4,
                    StudentId = 2,
                    SubmissionDate = new DateTime(2024, 06, 18, 0, 0, 0),
                    TheoryScore = 17.0m,
                    PracticalScore = 15.5m,
                    PresentationScore = 4.0m,
                    TotalGrade = 36.5m
                },
                new Project
                {
                    ProjectId = 5,
                    StudentId = 1,
                    SubmissionDate = new DateTime(2024, 06, 18, 0, 0, 0),
                    TheoryScore = 19.0m,
                    PracticalScore = 17.5m,
                    PresentationScore = 4.8m,
                    TotalGrade = 41.3m
                }



            );
        }
    }
}
