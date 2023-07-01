using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DataTransferObject;
using System.Data;

namespace GroupStudent.Presentation.Controllers
{
    [Route("api/groups/{GroupId}/students")]
    [ApiController]


    public class StudentsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public StudentsController(IServiceManager service) => _service = service;

        [HttpGet]
        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult GetStudentsForGroup(Guid GroupId)
        {
            var students = _service.StudentService.GetStudents(GroupId, trackChanges:
            false);
            return Ok(students);
        }


        [HttpGet("{id:guid}", Name = "GetStudentForGroup")]
        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult GetstudentForGroup(Guid groupId, Guid id)
        {
            var student = _service.StudentService.GetStudent(groupId, id,
            trackChanges: false);
            return Ok(student);


        }
        [HttpPost]
        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult CreateStudentForGroup(Guid GroupId, [FromBody] StudentForCreationDto student)
        {

            var studentToReturn = _service.StudentService.CreateStudentForGroup(GroupId, student, trackChanges: false);
            return Ok(studentToReturn);
        }
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult DeleteStudentForGroup(Guid Groupid, Guid id)
        {
            _service.StudentService.DeleteStudentForGroup(Groupid, id, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Teacher, Admin, Student")]
        public IActionResult UpdateStudentForGroup(Guid GroupId, Guid id, [FromBody] StudentForUpdateDto student)
        {
            if (student == null)
            {
                return BadRequest("StudentForUpdateDto object is null");
            }
            _service.StudentService.UpdateStudentForGroup(GroupId, id, student, grTrackChanges: false, stTrackChanges: true);
            return NoContent();
        }
    }

}
