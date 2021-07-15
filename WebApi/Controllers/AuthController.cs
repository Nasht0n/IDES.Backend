using System;
using System.Threading.Tasks;
using Application.Identity.Users.Commands;
using Application.Identity.Users.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Identity;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController:BaseController
    {
        private readonly IMapper _mapper;

        public AuthController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<SignInUserDetailVm>> SignIn([FromBody] SignInUserDto signInUserDto)
        {
            var query = _mapper.Map<SignInUserQuery>(signInUserDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Register([FromBody] RegisterUserDto createUserDto)
        {
            var command = _mapper.Map<RegisterUserCommand>(createUserDto);
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }

    }
}
