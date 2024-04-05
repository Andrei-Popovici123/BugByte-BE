using Microsoft.EntityFrameworkCore;

namespace BugByte.Data.Database;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}