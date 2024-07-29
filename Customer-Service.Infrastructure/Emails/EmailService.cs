using Customer_Service.Application.Core.Emails;

namespace Customer_Service.Infrastructure.Emails;

internal class EmailService : IEmailService
{
    public Task SendEmailAsync(string to, string from, string message)
    {
        throw new NotImplementedException();
    }
}
