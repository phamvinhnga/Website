using Website.Api.Filters;
using Website.Biz.Managers.Interfaces;
using Website.Entity.Model;
using Website.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Microsoft.Extensions.Options;

namespace Website.Api.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    [Authorize]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherManager _teacherManager;

        public TeacherController(
            ITeacherManager TeacherManager
        ) 
        {
            _teacherManager = TeacherManager;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _teacherManager.GetByIdAsync(id));
        }

        [HttpGet]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> GetListAsync([FromQuery] BasePageInputModel input)
        {
            return Ok(await _teacherManager.GetListAsync(input));
        }

        [HttpPost]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> CreateAsync([FromBody] TeacherInputModel input)
        {
            await _teacherManager.CreateAsync(input, User.Claims.GetUserId());
            return Ok(true);
        }

        [HttpPut]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> UpdateAsync([FromBody] TeacherInputModel input)
        {
            await _teacherManager.UpdateAsync(input, User.Claims.GetUserId());
            return Ok(true);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] TeacherInputModel input)
        {
            await _teacherManager.UpdateAsync(input, User.Claims.GetUserId());
            return Ok(true);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _teacherManager.DeleteAsync(id);
            return Ok(true);
        }
    }
}
