using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestExamen.Controllers;
using TestExamen.Models;
using TestExamen.Tests.Mocks;

namespace TestExamen.Tests.Controllers
{
    public class ProjectsControllerTests
    {
        [Test]
        public async Task GetProjects_ReturnsAllProjects()
        {
            //Arrange
            var mockProjectRepository = RepositoryMocks.GetMockProjectRepository();
            var controller = new ProjectsController(mockProjectRepository.Object);




            //Act
            var result = await controller.GetProjects();


            //Assert

            Assert.That(result.Value, Is.Not.Null);
            Assert.That(result.Value.Count(), Is.EqualTo(5));
        }

        [Test]
        public async Task GetProject_ValidId_ReturnsProject()
        {
            // Arrange
            var mockProjectRepository = RepositoryMocks.GetMockProjectRepository();
            var controller = new ProjectsController(mockProjectRepository.Object);

            // Act
            var result = await controller.GetProject(1);

            // Assert
            Assert.That(result.Value, Is.Not.Null);
            Assert.That(result.Value.ProjectId, Is.EqualTo(1));
            Assert.That(result.Value.Student.StudentName, Is.EqualTo("Van Damme, Lisa"));
        }
        [Test]
        public async Task PostProject_ValidProject_ReturnsCreatedAtAction()
        {
            // Arrange
            var mockProjectRepository = RepositoryMocks.GetMockProjectRepository();
            var controller = new ProjectsController(mockProjectRepository.Object);

            var newProject = new Project
            {
                ProjectId = 4,
                StudentId = 1,
                SubmissionDate = DateTime.Now,
                TheoryScore = 15m,
                PracticalScore = 15m,
                PresentationScore = 4m,
                TotalGrade = 34m
            };

            // Act
            var result = await controller.PostProject(newProject);

            // Assert
            Assert.That(result.Result, Is.TypeOf<CreatedAtActionResult>());
            var createdResult = result.Result as CreatedAtActionResult;
            Assert.That(createdResult.Value, Is.EqualTo(newProject));
        }

        [Test]
        public async Task DeleteProject_ValidId_ReturnsNoContent()
        {
            // Arrange
            var mockProjectRepository = RepositoryMocks.GetMockProjectRepository();
            var controller = new ProjectsController(mockProjectRepository.Object);

            // Act
            var result = await controller.DeleteProject(1);

            // Assert
            Assert.That(result, Is.TypeOf<NoContentResult>());
        }

        [Test]
        public async Task DeleteProject_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var mockProjectRepository = RepositoryMocks.GetMockProjectRepository();
            var controller = new ProjectsController(mockProjectRepository.Object);

            // Act
            var result = await controller.DeleteProject(999);

            // Assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
    }
}
