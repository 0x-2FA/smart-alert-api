using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace smart_alert_api.Models.Database;

public class SmartAlertContext : IdentityDbContext<EntityUser>
{
    public SmartAlertContext(DbContextOptions<SmartAlertContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
