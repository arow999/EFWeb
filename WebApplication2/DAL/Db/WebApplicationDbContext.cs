using Microsoft.EntityFrameworkCore;
namespace WebApplication2.DAL.Db
{
    public class WebApplicationDbContext : DbContext
    {
        public WebApplicationDbContext(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
              @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
        }
    }
}
