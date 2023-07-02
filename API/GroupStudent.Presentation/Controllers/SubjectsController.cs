using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DataTransferObject;
using System.Data;

namespace GroupStudent.Presentation.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public SubjectsController(IServiceManager service) => _service = service;

        [HttpPost]
        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult CreateSubject([FromBody] SubjectForCreationDto subjectDto)
        {
            var subject = _service.SubjectService.CreateSubject(subjectDto, trackChanges: false);
            return Ok(subject);
        }
        [HttpGet]
        [Authorize(Roles = "Teacher, Admin, Student")]
        public IActionResult GetAllSubjects()
        {
            var subjects = _service.SubjectService.GetSubjects(trackChanges: false);
            if (subjects == null)
            {
                return BadRequest();
            }
            else { return Ok(subjects); }

        }
        [HttpGet("/GetSubjectsById/{SubjectId}")]
        [Authorize(Roles = "Teacher, Admin, Student")]
        public IActionResult GetSubjectsById(Guid SubjectId)
        {
            var subjects = _service.SubjectService.GetSubjectById(SubjectId, trackChanges: false);
            if (subjects == null)
            {
                return BadRequest();
            }
            else { return Ok(subjects); }
        }
        [HttpDelete("/DeleteSubject/{SubjectId}")]
        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult DeleteSubjectById(Guid SubjectId)
        {
            _service.SubjectService.DeleteSubject(SubjectId, trackChanges: false);
            return NoContent();
        }

    }
}
