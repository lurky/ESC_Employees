using EmployeeApi.Operations;
using EmployeeData.Contracts;
using Microsoft.AspNetCore.Mvc;
using Unity;

namespace EmployeeApi.Controllers
{
    [ApiController]
  [Route("[controller]")]
  public class EmployeeController : ControllerBase
  {
    private readonly ILogger<EmployeeController> _logger;
    private readonly IUnityContainer _container;

    public EmployeeController(ILogger<EmployeeController> logger, IUnityContainer container)
    {
      _logger = logger;
      _container = container;
    }

    [HttpGet]
    public async Task<List<EmployeeData.DTO.Employee>> Get()
    {
      _logger.LogTrace("Getting all employees");
      return await _container.Resolve<GetEmployeesOperation>().ExecuteAsync();
       
    }

    [HttpGet("search")]
    public async Task<List<EmployeeData.DTO.Employee>> GetByProperty([FromQuery] int? id, [FromQuery] string? firstName, [FromQuery] string? lastName, [FromQuery] string? email, [FromQuery] string? departmentName, [FromQuery] string? countryName, [FromQuery] string? regionName)
    {
      _logger.LogTrace($"Getting employee with property search");
      return await _container.Resolve<GetEmployeesByPropertyOperation>().ExecuteAsync(id, firstName, lastName, email, departmentName, countryName, regionName);
    }
  }
}
