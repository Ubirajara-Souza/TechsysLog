using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bira.App.TechsysLog.Infra.Repositories.BaseContext
{
    public class IdentDbContext : IdentityDbContext
    {
        public IdentDbContext(DbContextOptions<IdentDbContext> options) : base(options) { }
    }
}
