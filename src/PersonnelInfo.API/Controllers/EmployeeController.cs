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
    public async Task<IActionResult> Get(string id, CancellationToken cancellationToken = default)
    {
        if (int.TryParse(id, out int parsedId))
        {
            var employee = await _services.GetByIdAsync(parsedId, cancellationToken);
            return Ok(employee);
        }

        return BadRequest("Invalid ID format.");
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
