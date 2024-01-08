using Clinic.Data;
using Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics;

namespace Clinic.Services
{
    public class DataService2
    {
        //private readonly Guid _tenantId;
        //private readonly IDbContextFactory<ApplicationDbContext> factory;
        //private ApplicationDbContext context;
        //public DataService2(IDbContextFactory<ApplicationDbContext> factory, ITenantProvider tenantProvider)
        //{
        //    this.factory = factory;
        //    _tenantId = tenantProvider.GetTenantId();
        //    context = factory.CreateDbContext();
        //}

        //public async Task<bool> SaveLabCase(LabCase labcase)
        //{
        //    using (var context = factory.CreateDbContext()) //using disposes the dbcontext after use.
        //    {
        //        context.LabCases.Update(labcase);
        //        await context.SaveChangesAsync();

        //    }
        //    return true;
        //}

        //public async Task<List<LabCase>> GetLabCasesAsync(int TreatmentJournalId)
        //{
        //    using (var context = factory.CreateDbContext()) //using disposes the dbcontext after use.
        //    {
        //        var lc = await context.LabCases.Where(t => t.TreatmentJournalId == TreatmentJournalId)
        //            .ToListAsync();
        //        return lc;

        //    }

        //}

        //public List<LabCase> GetLabCases(int TreatmentJournalId)
        //{
        //    using (var context = factory.CreateDbContext()) //using disposes the dbcontext after use.
        //    {
        //        var lc = context.LabCases.Where(t => t.TreatmentJournalId == TreatmentJournalId)
        //            .ToList();
        //        return lc;

        //    }

        //}



        //public async Task<bool> SaveImplant(ImplantModel implant)
        //{
        //    using (var context = factory.CreateDbContext()) //using disposes the dbcontext after use.
        //    {
        //        context.Implants.Update(implant);
        //        await context.SaveChangesAsync();

        //    }
        //    return true;
        //}

        //public async Task<bool> DeleteLabCase(LabCase labcase)
        //{
        //    using (var context = factory.CreateDbContext()) //using disposes the dbcontext after use.
        //    {

        //        var response = context.LabCases.Remove(labcase);
        //        await context.SaveChangesAsync();
        //        return true;
        //    }

        //}

        //public async Task<List<ImplantModel>> GetImplantsAsync(int TreatmentJournalId)
        //{
        //    using (var context = factory.CreateDbContext()) //using disposes the dbcontext after use.
        //    {
        //        var tj = await context.Treatments.Where(t=>t.TreatmentJournalId == TreatmentJournalId)
        //            .Include(t=>t.Implants)
        //            .SingleOrDefaultAsync();
        //        return tj.Implants;    

        //    }
            
        //}

        //public List<ImplantModel> GetImplants(int TreatmentJournalId)
        //{
        //    using (var context = factory.CreateDbContext()) //using disposes the dbcontext after use.
        //    {
        //        var tj = context.Treatments.Where(t => t.TreatmentJournalId == TreatmentJournalId)
        //            .Include(t => t.Implants)
        //            .SingleOrDefault();
        //        return tj.Implants;

        //    }

        //}

        //public async Task<bool> DeleteImplant(ImplantModel implant)
        //{
        //    using (var context = factory.CreateDbContext()) //using disposes the dbcontext after use.
        //    {
                
        //        var response = context.Implants.Remove(implant);
        //        await context.SaveChangesAsync();
        //        return true;
        //    }

        //}

        //public List<VisitProcedure> GetProcedures(int TreatmentJournalId)
        //{
        //    using (var context = factory.CreateDbContext()) //using disposes the dbcontext after use.
        //    {

        //        var response = context.VisitProcedures.Where(p=>p.TreatmentJournalId == TreatmentJournalId).ToList();
        //        return response;
        //    }
        //}

    }
}
