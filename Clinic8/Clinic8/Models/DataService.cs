using Clinic.Data;
using Clinic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NuGet.Configuration;
//using Syncfusion.EJ2.Navigations;
using System.Data;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static MudBlazor.CategoryTypes;
using static System.Formats.Asn1.AsnWriter;

namespace Clinic.Models
{
    public interface IData
    {
        
    }
    [Authorize]
    public class DataService : IData
    {
        private readonly Guid _tenantId;

        private readonly IServiceScopeFactory _scopeFactory;
        public DataService(IServiceScopeFactory serviceScopeFactory, ITenantProvider tenantProvider)
        {
            _scopeFactory = serviceScopeFactory;
            _tenantId = tenantProvider.GetTenantId();


        }

        
    }
}


/*
var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
try
{
    var existingJournal = await context.Treatments
        .Include(j => j.Procedures)
        .Include(j => j.Lab)
        .Include(j => j.LabCaseType)
        .Include(j => j.LabCases)
            .ThenInclude(lc => lc.Lab)
        .Include(j => j.LabCases)
            .ThenInclude(lc => lc.LabCaseType)
        .FirstOrDefaultAsync(j => j.TreatmentJournalId == item.TreatmentJournalId);

    if (existingJournal != null)
    {
        // Update the properties of the existing entity
        existingJournal.AppointmentDate = item.AppointmentDate;
        existingJournal.DateDue = item.DateDue;
        existingJournal.DateOfImpression = item.DateOfImpression;
        existingJournal.DateReceived = item.DateReceived;
        existingJournal.DateSent = item.DateSent;
        existingJournal.Due = item.Due;
        existingJournal.NextAppointment = item.NextAppointment;
        existingJournal.NextVisitWork = item.NextVisitWork;
        existingJournal.Notes = item.Notes;
        existingJournal.Paid = item.Paid;
        existingJournal.PatientId = item.PatientId;
        existingJournal.TenantId = item.TenantId;
        existingJournal.ToothNumber = item.ToothNumber;
        existingJournal.TreatmentDate = item.TreatmentDate;
        existingJournal.TreatmentDateTime = item.TreatmentDateTime;

        // Update the related entities
        existingJournal.Procedures.Clear();
        existingJournal.Procedures.AddRange(item.Procedures);
        existingJournal.Lab = item.Lab;
        existingJournal.LabCaseType = item.LabCaseType;
        existingJournal.LabCases.Clear();
        existingJournal.LabCases.AddRange(item.LabCases);

        // Save the changes
        await context.SaveChangesAsync();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

*/