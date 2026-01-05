using System.ComponentModel.DataAnnotations;

namespace TestExamen.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string? StudentName { get; set; }

        public List<Project>? Projects { get; set; }
    }
}
