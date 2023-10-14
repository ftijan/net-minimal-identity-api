using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Example.MinimalIdentityApi
{
	public class AppIdentityContext : IdentityDbContext<AppIdentityUser>
	{
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options)
        {
            
        }
    }
}
