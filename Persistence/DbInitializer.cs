namespace Persistence
{
    public class DbInitializer
    {
        public static void Initialize(IdesDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}