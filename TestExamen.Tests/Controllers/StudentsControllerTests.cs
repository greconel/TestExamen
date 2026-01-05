using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestExamen.Controllers;
using TestExamen.Tests.Mocks;

namespace TestExamen.Tests.Controllers
{
    [TestFixture]
    public class StudentsControllerTests
    {
        [Test]
        public async Task GetStudents_ReturnsAllStudents()
        {
            // Arrange
            var mockStudentRepository = RepositoryMocks.GetMockStudentRepository();
            var controller = new StudentsController(mockStudentRepository.Object);

            // Act
            var result = await controller.GetStudents();

            // Assert
            Assert.That(result.Value, Is.Not.Null);
            Assert.That(result.Value.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task GetStudent_ValidId_ReturnsStudent()
        {
            // Arrange
            var mockStudentRepository = RepositoryMocks.GetMockStudentRepository();
            var controller = new StudentsController(mockStudentRepository.Object);

            // Act
            var result = await controller.GetStudent(1);

            // Assert
            Assert.That(result.Value, Is.Not.Null);
            Assert.That(result.Value.StudentId, Is.EqualTo(1));
            Assert.That(result.Value.StudentName, Is.EqualTo("Van Damme, Lisa"));
        }

        [Test]
        public async Task GetStudent_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var mockStudentRepository = RepositoryMocks.GetMockStudentRepository();
            var controller = new StudentsController(mockStudentRepository.Object);

            // Act
            var result = await controller.GetStudent(999);

            // Assert
            Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
        }
    }
}
