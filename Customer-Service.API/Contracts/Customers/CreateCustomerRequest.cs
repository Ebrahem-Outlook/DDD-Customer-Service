namespace Customer_Service.API.Contracts.Customers;

public sealed record CreateCustomerRequest(
    string FirstName, 
    string LastName, 
    string Email,
    string Phone,
    string Street, 
    string City, 
    string State,
    string ZipCode);

