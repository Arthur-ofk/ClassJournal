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
        public IActionResult CreateMark([FromBody] MarkForCreationDto markForCreation)
        {
            var markToreturn = _serviceManager.MarkService.CreateMark(markForCreation, trackChanges: false);
            return Ok(markToreturn);
        }
        [HttpGet("studentMarks/({StudentId:guid})/({markId:guid})")]
        public IActionResult GetSubjectMarksForStudent(Guid StudentId, Guid markId)
        {
            var subjectMarks = _serviceManager.MarkService.GetSubjectMarksForStudents(StudentId, markId, trackChanges: false);
            return Ok(subjectMarks);
        }
        [HttpGet("({StudentId:guid})")]
        public IActionResult GetAllMarksForStudent(Guid StudentId)
        {
            var marks = _serviceManager.MarkService.GetAllMarksForStudent(StudentId, trackChanges: false);
            return Ok(marks);
        }

    }
}
