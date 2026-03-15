using Microsoft.AspNetCore.Identity;

namespace Auth.Wiedersehen.Users;

public class ApplicationUser : IdentityUser
{
	public DateTime TermsAcceptanceTime { get; set; }
}
