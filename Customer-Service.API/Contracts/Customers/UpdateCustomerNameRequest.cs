namespace Customer_Service.API.Contracts.Customers;

public sealed record UpdateCustomerNameRequest(
    string FirstName,
    string LastName);

