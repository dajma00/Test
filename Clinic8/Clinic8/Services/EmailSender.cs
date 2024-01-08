using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PostmarkDotNet;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Clinic.Services
{
    public class EmailSender : IEmailSender
    { 
        //used for sending emails for user registrations.
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }
        public async Task SendEmailAsync(string toEmail, string name, string url)
        {
            await Execute(toEmail, name, url);
        }

        public async Task Execute(string toEmail, string name, string url)
        {
            var templatedMessage = new TemplatedPostmarkMessage(); //https://github.com/wildbit/postmark-dotnet/wiki/Sending-Using-a-Template
            templatedMessage.To = toEmail;
            templatedMessage.TemplateId = 33760225;
            templatedMessage.TemplateModel = new
            {
                Name = name,
                Url = url
            };
            templatedMessage.TrackOpens = true;
            templatedMessage.Tag = "noreply@kfacon.com";
            templatedMessage.From = "noreply@kfacon.com";
            templatedMessage.ReplyTo = "noreply@kfacon.com";
            var client = new PostmarkClient("replace with your own key");
            var sendResult = await client.SendEmailWithTemplateAsync(templatedMessage);


            
            _logger.LogInformation((sendResult.Status == PostmarkStatus.Success)
                                   ? $"Email to {toEmail} queued successfully!"
                                   : $"Failure Email to {toEmail}");
        }
    }
}
