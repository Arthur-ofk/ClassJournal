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
    [Route("api/subject")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public SubjectsController(IServiceManager service) => _service = service;

        [HttpPost]
        public  IActionResult CreateSubject([FromBody] SubjectForCreationDto subjectDto)
        {
             var subject =  _service.SubjectService.CreateSubject(subjectDto, trackChanges : false);
            return Ok(subject);
        }
        [HttpGet]
        public IActionResult GetAllSubjects()
        {
           var subjects =  _service.SubjectService.GetSubjects(trackChanges: false);
            if(subjects == null)
            {
                return BadRequest();
            }
            else { return Ok(subjects); }
            
        }
        [HttpGet("/GetSubjectsByName/{name}")]
        public IActionResult GetSubjectsByName(string name)
        {
            var subjects = _service.SubjectService.GetSubjectsByName(name, trackChanges: false);
            if (subjects == null)
            {
                return BadRequest();
            }
            else { return Ok(subjects); }
        }
    }
}
