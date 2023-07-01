using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DataTransferObject;

namespace GroupStudent.Presentation.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public GroupsController(IServiceManager service) => _service = service;
        [HttpGet("/getgroupbyid/{id}")]
        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult GetGroup(Guid id)
        {
            try
            {
                var groups =
                _service.GroupService.GetGroup(id, trackChanges: false);
                return Ok(groups);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        [Authorize(Roles = "Teacher, Admin, Student")]
        public IActionResult GetAllGroups()
        {
            try
            {
                var groups =
                _service.GroupService.GetAllGroups(trackChanges: false);
                return Ok(groups);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult CreateGroup([FromBody] GroupForCreationDto group)
        {

            var createdGroup = _service.GroupService.CreateGroup(group);
            return Ok(createdGroup);

        }
        [HttpGet("collection/({ids})", Name = "GroupCollection")]
        [Authorize(Roles = "Teacher, Admin, Student")]
        public IActionResult GetGroupCollection(IEnumerable<Guid> ids)
        {
            var groups = _service.GroupService.GetByIds(ids, trackChanges: false);
            return Ok(groups);
        }
        [HttpPost("collection")]
        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult CreateGroupCollection([FromBody]
             IEnumerable<GroupForCreationDto> companyCollection)
        {
            var result =
            _service.GroupService.CreateGroupCollection(companyCollection);
            return Ok(result);

        }
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult DeleteGroup(Guid id)
        {
            _service.GroupService.DeleteGroup(id, trackChanges: false);
            return NoContent();
        }

    }

}
