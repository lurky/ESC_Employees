using EmployeeData.Contracts;
using EmployeeData.DTO;

namespace EmployeeApi.Operations
{
  public class GetEmployeesOperation
  {
    public GetEmployeesOperation(IEmployeeRepo employeeRepo)
    {
      _employeeRepo = employeeRepo;
    }

    public async Task<List<Employee>> ExecuteAsync()
    {
      return await _employeeRepo.GetEmployees();
    }

    private readonly IEmployeeRepo _employeeRepo;
  }
}
