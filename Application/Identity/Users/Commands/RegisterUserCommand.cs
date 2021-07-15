using System;
using MediatR;

namespace Application.Identity.Users.Commands
{
    public class RegisterUserCommand:IRequest<Guid>
    {
        public Guid EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
