using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestExamen.Models;
using Moq;

namespace TestExamen.Tests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IProjectRepository> GetMockProjectRepository()
        {
            var projects = GetProjects();

            var mockProjectRepository = new Mock<IProjectRepository>();

            mockProjectRepository.Setup(repo => repo.GetProjectsAsync()).ReturnsAsync(projects);
            mockProjectRepository.Setup(repo => repo.GetProjectAsync(It.IsAny<int>())).ReturnsAsync((int id) => projects.FirstOrDefault(p => p.ProjectId ==id));


            return mockProjectRepository;
        }

        public static Mock<IStudentRepository> GetMockStudentRepository()
        {
            var students = GetStudents();
            var mockStudentRepository = new Mock<IStudentRepository>();

            mockStudentRepository.Setup(m => m.GetStudentsAsync()).ReturnsAsync(students);
            mockStudentRepository.Setup(m => m.GetStudentByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => students.FirstOrDefault(s => s.StudentId == id));

            return mockStudentRepository;
        }

        private static List<Project> GetProjects()
        {
            var students = GetStudents();
            return new List<Project>
            {
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
                    TheoryScore = 18.0m,
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
            };
        }

        

        private static  List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student { StudentId = 1, StudentName = "Van Damme, Lisa" },
                new Student { StudentId = 2, StudentName = "Janssens, Thomas" },
                new Student { StudentId = 3, StudentName = "Peeters, Emma" }
            };

        }
    }
}
