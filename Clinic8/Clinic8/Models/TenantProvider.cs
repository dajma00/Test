using Clinic.Data;
using Clinic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clinic.Models
{

    public interface ITenantProvider
    {
        Guid GetTenantId();
        Task<Guid> GetTenantIdAsync();
    }
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TenantDbContext _tenantDbContext;


        private Guid _tenantId;

        public TenantProvider(TenantDbContext tenantDbContext,
                          IHttpContextAccessor httpContextAccessor)
        {

            _tenantDbContext = tenantDbContext;
            _httpContextAccessor = httpContextAccessor;
            _tenantDbContext = tenantDbContext;

        }

        private async void SetTenantId()
        {
            if (_httpContextAccessor != null && _httpContextAccessor.HttpContext != null)
            {
                ClaimsPrincipal user = _httpContextAccessor.HttpContext.User;
                var _userId = user.FindFirst(ClaimTypes.NameIdentifier); //ClaimTypes.NameIdentified return userid
                string email = null;
                if (user.FindFirst(ClaimTypes.Email) != null)
                {
                    email = user.FindFirst(ClaimTypes.Email).Value ?? null;                                                         //
                                                                                                                                    //var name = user.FindFirst(ClaimTypes.Name); //doesnt work
                                                                                                                                    //var httuser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User); //doesnt work
                }
                if (_userId != null && _userId.Value != null)
                {
                    //using (var scope = scopeFactory.CreateScope())
                    {
                        //var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                        _tenantId = _tenantDbContext.Tenants.AsNoTracking().Where(u => u.UserId == _userId.Value).Select(s => s.TenantId).FirstOrDefault();

                    }

                    return;
                }
                else if (email != null)
                {
                    {
                        //var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                        _tenantId = _tenantDbContext.Tenants.AsNoTracking().Where(u => u.Email.ToLower() == email.ToLower()).Select(s => s.TenantId).FirstOrDefault();
                    }
                    return;
                }
                else
                {

                    // Whatever you would like to return if there is no request (eg. on startup of app).
                    _tenantId = Guid.NewGuid();
                    //_tenantId = Guid.Parse("111-111-111-111");
                    return;
                }
            }
            else
            {
                // Whatever you would like to return if there is no request (eg. on startup of app).
                _tenantId = Guid.NewGuid();
                return;
            }


        }
        private async Task SetTenantIdAsync()
        {
            if (_httpContextAccessor != null && _httpContextAccessor.HttpContext != null)
            {
                ClaimsPrincipal user = _httpContextAccessor.HttpContext.User;
                var _userId = user.FindFirst(ClaimTypes.NameIdentifier); //ClaimTypes.NameIdentified return userid
                string email = null;
                if (user.FindFirst(ClaimTypes.Email) != null)
                {
                    email = user.FindFirst(ClaimTypes.Email).Value ?? null;                                                         //
                                                                                                                                    //var name = user.FindFirst(ClaimTypes.Name); //doesnt work
                                                                                                                                    //var httuser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User); //doesnt work
                }
                if (_userId != null && _userId.Value != null)
                {
                    {
                        //var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                        _tenantId = await _tenantDbContext.Tenants.AsNoTracking().Where(u => u.UserId == _userId.Value).Select(s => s.TenantId).FirstOrDefaultAsync();

                    }

                    return;
                }
                else if (email != null)
                {
                    {
                        //var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                        _tenantId = await _tenantDbContext.Tenants.AsNoTracking().Where(u => u.Email.ToLower() == email.ToLower()).Select(s => s.TenantId).FirstOrDefaultAsync();
                    }
                    return;
                }
                else
                {
                    // Whatever you would like to return if there is no request (eg. on startup of app).
                    _tenantId = Guid.NewGuid();
                    return;
                }
            }
            else
            {
                // Whatever you would like to return if there is no request (eg. on startup of app).
                _tenantId = Guid.NewGuid();
                return;
            }


        }
        public Guid GetTenantId()
        {
            SetTenantId();
            return _tenantId;
        }
        public async Task<Guid> GetTenantIdAsync()
        {
            await SetTenantIdAsync();
            return _tenantId;
        }
    }
}
