using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupStudent.Presentation.Controllers
{
    [Route("api/groups/{GroupId}/students")]
    [ApiController]

        
        public class StudentsController : ControllerBase
        {
            private readonly IServiceManager _service;
            public StudentsController(IServiceManager service) => _service = service;
            
            [HttpGet]
            public IActionResult GetStudentsForGroup(Guid GroupId)
            {
                var students = _service.StudentService.GetStudents(GroupId, trackChanges:
                false);
                return Ok(students);
            }


            [HttpGet("{id:guid}", Name = "GetStudentForGroup")]
            public IActionResult GetstudentForGroup(Guid groupId, Guid id)
            {
                var student = _service.StudentService.GetStudent(groupId, id,
                trackChanges: false);
                return Ok(student);


            }
            [HttpPost]
            public IActionResult CreateStudentForGroup(Guid GroupId, [FromBody] StudentForCreationDto student)
             {

               var studentToReturn = _service.StudentService.CreateStudentForGroup(GroupId, student, trackChanges: false);
            return Ok(studentToReturn);
             }
            [HttpDelete("{id:guid}")]
            public IActionResult DeleteStudentForGroup(Guid Groupid, Guid id)
        {
            _service.StudentService.DeleteStudentForGroup(Groupid, id,trackChanges : false);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateStudentForGroup(Guid groupId, Guid id, [FromBody] StudentForUpdateDto student)
        {
            if (student == null)
            {
                return BadRequest("EmployeeForUpdateDto object is null");
            }
            _service.StudentService.UpdateStudentForGroup(groupId, id, student, grTrackChanges: false, stTrackChanges: true);
            return NoContent();
        }
    }
    
}
