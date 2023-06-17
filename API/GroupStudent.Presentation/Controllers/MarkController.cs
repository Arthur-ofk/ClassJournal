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
    [Route("api/mark")]
    [ApiController]
    public class MarkController :ControllerBase
    {
        public readonly IServiceManager _serviceManager;
        public MarkController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpPost]
        public IActionResult CreateMark([FromBody]MarkForCreationDto markForCreation)
        {
           var markToreturn= _serviceManager.MarkService.CreateMark(markForCreation, trackChanges: false);
            return Ok(markToreturn);
        }

    }
}
