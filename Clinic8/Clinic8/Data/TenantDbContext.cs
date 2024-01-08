using Clinic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Data
{
    public class TenantDbContext : IdentityDbContext
    {
        public TenantDbContext(
            DbContextOptions<TenantDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Tenant> Tenants { get; set; } 
    }
}
