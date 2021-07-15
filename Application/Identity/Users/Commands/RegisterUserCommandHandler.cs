using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Identity.Users.Commands
{
    public class RegisterUserCommandHandler:IRequestHandler<RegisterUserCommand,Guid>
    {
        private readonly IDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserCommandHandler(IDbContext context, UserManager<AppUser> userManager) =>
            (_context, _userManager) = (context, userManager);

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser()
            {
                EmployeeId = request.EmployeeId,
                UserName = request.Username
            };
            await _userManager.CreateAsync(user, request.Password);
            return Guid.Parse(user.Id);
        }
    }
}
