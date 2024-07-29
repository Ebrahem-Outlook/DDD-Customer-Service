namespace Customer_Service.Application.Core.Emails;

public interface IEmailService
{
    Task SendEmailAsync(string to, string from, string message);
}
