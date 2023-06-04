using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Group
    {
        //[Column("GroupId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Group name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        
        public string? GroupName { get; set; }
        [Required(ErrorMessage = "GroupCourse is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Course is 60 characters")]

        public int GroupCourse { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}
