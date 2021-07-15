using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Domain.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Identity.Users.Queries
{
    public class SignInUserQueryHandler:IRequestHandler<SignInUserQuery, SignInUserDetailVm>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SignInUserQueryHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) =>
            (_userManager, _signInManager) = (userManager, signInManager);

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
                    EmployeeId = user.EmployeeId
                };
            }

            throw new RestException(HttpStatusCode.Unauthorized);
        }
    }
}
