using EmployeeData.Contracts;
using EmployeeData.DTO;

namespace EmployeeApi.Operations
{
  public class GetEmployeesByPropertyOperation
  {
    public GetEmployeesByPropertyOperation(IEmployeeRepo employeeRepo)
    {
      _employeeRepo = employeeRepo;
    }

    public async Task<List<Employee>> ExecuteAsync(int? id, string? firstName, string? lastName, string? email, string? departmentName, string? countryName, string? regionName)
    {
      return await _employeeRepo.GetByProperty(id, firstName, lastName, email, departmentName, countryName, regionName);
    }

    private readonly IEmployeeRepo _employeeRepo;
  }
}