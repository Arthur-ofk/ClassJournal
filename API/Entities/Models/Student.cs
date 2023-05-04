using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Student
    {
        [Column("Id")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Student name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? StudentName { get; set; }
        public int StudentAge { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adress { get; set; }
        public bool IsStateLearning { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public Guid GroupId { get; set; }
        public Group? Group { get; set; }


    }
}
