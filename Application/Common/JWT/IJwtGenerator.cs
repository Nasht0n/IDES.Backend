using Domain.Models.Identity;

namespace Application.Common.JWT
{
    public interface IJwtGenerator
    {
        string CreateToken(AppUser user);
    }
}
