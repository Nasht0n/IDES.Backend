using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence
{
    public class IdesContextFactory : IDesignTimeDbContextFactory<IdesDbContext>
    {
        public IdesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdesDbContext>();
            optionsBuilder.UseSqlServer("Server=(local);Database=IDES;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new IdesDbContext(optionsBuilder.Options);
        }
    }
}
