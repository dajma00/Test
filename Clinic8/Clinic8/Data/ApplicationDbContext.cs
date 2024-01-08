using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clinic.Models;
using Microsoft.Extensions.Hosting;
using System.Security.Permissions;

namespace Clinic.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private Guid _tenantId;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ITenantProvider _tenantProvider)
            : base(options)
        {
            _tenantId = _tenantProvider.GetTenantId();

        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    //Write Fluent API configurations here

            //    //Property Configurations
            base.OnModelCreating(modelBuilder);

            

        }
    }
}