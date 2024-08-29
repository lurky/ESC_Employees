using EmployeeData.Models;

namespace EmployeeData.Contracts
{
    public interface IEmployeeRepo : IRepositoryBase<Employee>
  {
    Task<List<DTO.Employee>> GetByProperty(int? id, string? firstName, string? lastName, string? email, string? departmentName, string? countryName, string? regionName);
    Task<List<DTO.Employee>> GetEmployees();
  }
}
