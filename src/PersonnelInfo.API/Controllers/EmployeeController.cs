using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PersonnelInfo.Application.Services;
using PersonnelInfo.Core.Interfaces;
using PersonnelInfo.Shared.Exceptions.Infrastructure;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonnelInfo.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    readonly ILogger<EmployeeController> _logger;
    readonly IEmployeeServices _services;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeServices services)
    {
        _logger = logger;
        _services = services;
    }

    //// GET: api/<EmployeeController>
    //[HttpGet]
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}

    // GET api/<EmployeeController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id Cancellation )
    {
        try
        {
            var employee = await _services.GetByIdAsync(id, cancellationToken);
            return Ok(employee);
        }
        catch (NotFoundEntity)
        {
            return NotFound($"Employee with ID {id} was not found.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Unexpected error: {ex.Message}");
        }
    }

    //// POST api/<EmployeeController>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/<EmployeeController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<EmployeeController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}
