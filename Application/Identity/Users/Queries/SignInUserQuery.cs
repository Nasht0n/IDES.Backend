using MediatR;

namespace Application.Identity.Users.Queries
{
    public class SignInUserQuery:IRequest<SignInUserDetailVm>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
