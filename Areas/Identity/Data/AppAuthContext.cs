using HomeOwnersApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeOwnersApp.Data;

public class AppAuthContext : IdentityDbContext<AppUser>
{
    public AppAuthContext(DbContextOptions<AppAuthContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
