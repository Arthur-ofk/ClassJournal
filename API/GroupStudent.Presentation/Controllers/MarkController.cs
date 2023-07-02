﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DataTransferObject;

namespace GroupStudent.Presentation.Controllers
{
    [Route("api/mark")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        public readonly IServiceManager _serviceManager;
        public MarkController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpPost]
        [Authorize(Roles ="Teacher, Admin")]
        public IActionResult CreateMark([FromBody] MarkForCreationDto markForCreation)
        {
            var markToreturn = _serviceManager.MarkService.CreateMark(markForCreation, trackChanges: false);
            return Ok(markToreturn);
        }
        [Authorize(Roles = "Teacher, Admin, Student")]
        [HttpGet("studentMarks/({StudentId:guid})/({SubjectId:guid})")]
        public IActionResult GetSubjectMarksForStudent(Guid StudentId, Guid SubjectId)
        {
            var subjectMarks = _serviceManager.MarkService.GetSubjectMarksForStudents(StudentId, SubjectId, trackChanges: false);
            return Ok(subjectMarks);
        }
        [HttpGet("({StudentId:guid})")]
        [Authorize(Roles = "Teacher, Admin, Student")]
        public IActionResult GetAllMarksForStudent(Guid StudentId)
        {
            var marks = _serviceManager.MarkService.GetAllMarksForStudent(StudentId, trackChanges: false);
            return Ok(marks);
        }
        [HttpGet("(MarkId)")]
        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult GetMarkById(Guid MarkId)
        {
           var mark = _serviceManager.MarkService.GetMarkById(MarkId, trackChanges: false);
            return Ok(mark);
        }
        [HttpDelete("(MarkId)")]
        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult DeleteMarkById(Guid MarkId)
        {
            _serviceManager.MarkService.DeleteMarkForStudent(MarkId, trackChanges: false);
            return NoContent();
        }

    }
}