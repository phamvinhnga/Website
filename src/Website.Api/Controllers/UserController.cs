﻿using AutoMapper;
using Website.Api.Filters;
using Website.Biz.Dto;
using Website.Biz.Managers.Interfaces;
using Website.Entity.Model;
using Website.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Website.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public UserController(
            IUserManager userManager,
            IMapper mapper
        )
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("staff")]
        [Authorize(Roles = RoleExtension.Admin)]
        public async Task RegisterStaffAsync([FromBody] StaffRegisterInputDto input)
        {
            var staff = _mapper.Map<StaffRregisterInputModel>(input);
            await _userManager.RegisterStaffAsync(staff);
        }

        [HttpGet("staff")]
        //[Authorize(Roles = RoleExtension.Admin, Policy = PolicyExtension.Manager_Account_Staff)]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> GetListStaffAsync()
        {
            var retult = await _userManager.GetListStaffAsync();
            return Ok(_mapper.Map<List<StaffOutputDto>>(retult));
        }
    }
}
