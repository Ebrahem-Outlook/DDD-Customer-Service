using Customer_Service.Application.Customers.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Customer_Service.API.Controller;

[ApiController]
[Route("api/[Controller]")]
public sealed class CustomersController(ISender sender) : ControllerBase
{


    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllCustomersQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await sender.Send(new GetByIdCustomerQuery(id)));

    public async Task<IActionResult> GetByEmail(string email) => Ok(await sender.Send(new GetByCustomerEmailQuery(eamil)));
}
