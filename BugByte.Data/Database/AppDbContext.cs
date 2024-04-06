using System.Net.Mime;
using BugByte.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugByte.Data.Database;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Application> Applications { get; set; }
}