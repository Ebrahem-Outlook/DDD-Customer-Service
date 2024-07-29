using Customer_Service.Domain.Customers;

namespace Customer_Service.Application.Core.Authentication;

public interface IJwtProvider
{
    Task<string> GenerateToken(Customer customer);
}
