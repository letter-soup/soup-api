using Auth.Wiedersehen.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.Wiedersehen.Database.Migrations;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
	: IdentityDbContext<ApplicationUser>(options)
{
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		// Customize the ASP.NET Identity model and override the defaults if needed.
		// For example, you can rename the ASP.NET Identity table names and more.
		// Add your customizations after calling base.OnModelCreating(builder);
	}
}
