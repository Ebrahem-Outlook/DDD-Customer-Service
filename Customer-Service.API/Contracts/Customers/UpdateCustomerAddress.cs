namespace Customer_Service.API.Contracts.Customers;

public sealed record UpdateCustomerAddress(
    string Street,
    string City, 
    string State,
    string ZipCode);

