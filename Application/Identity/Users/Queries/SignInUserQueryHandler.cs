using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.JWT;
using Domain.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Identity.Users.Queries
{
    public class SignInUserQueryHandler:IRequestHandler<SignInUserQuery, SignInUserDetailVm>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;

        public SignInUserQueryHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator) =>
            (_userManager, _signInManager, _jwtGenerator) = (userManager, signInManager,jwtGenerator);

        public async Task<SignInUserDetailVm> Handle(SignInUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                throw new NotFoundException(nameof(AppUser), request.Username);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                return new SignInUserDetailVm()
                {
                    Id = Guid.Parse(user.Id),
                    Token = _jwtGenerator.CreateToken(user),
                    EmployeeId = user.EmployeeId
                };
            }

            throw new RestException(HttpStatusCode.Unauthorized);
        }
    }
}
