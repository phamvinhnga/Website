﻿using Website.Api.Filters;
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
    [ServiceFilter(typeof(AdminRoleFilter))]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherManager _teacherManager;

        public TeacherController(
            ITeacherManager teacherManager
        ) 
        {
            _teacherManager = teacherManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _teacherManager.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] BasePageInputModel input)
        {
            return Ok(await _teacherManager.GetListAsync(input));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TeacherInputModel input)
        {
            await _teacherManager.CreateAsync(input, User.Claims.GetUserId());
            return Ok(true);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] TeacherInputModel input)
        {
            await _teacherManager.UpdateAsync(input, User.Claims.GetUserId());
            return Ok(true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] TeacherInputModel input)
        {
            await _teacherManager.UpdateAsync(input, User.Claims.GetUserId());
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _teacherManager.DeleteAsync(id);
            return Ok(_teacherManager.DeleteAsync(id));
        }
    }
}
