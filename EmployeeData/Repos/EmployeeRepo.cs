using AutoMapper;
using EmployeeData.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData.Repos
{
    public class EmployeeRepo : RepositoryBase<Models.Employee>, IRepositoryBase<Models.Employee>, IEmployeeRepo
  {
    public MasterContext _Context;
    private readonly IMapper _Mapper;
    public EmployeeRepo(MasterContext context, IMapper mapper) : base(context)
    {
      _Context = context;
      _Mapper = mapper;
    }

    public async Task<List<DTO.Employee>> GetEmployees()
    {
      var dataModels = await _Context.Employees
        .Include(e => e.Dependents)
        .Include(e => e.Department).ThenInclude(e => e.Location).ThenInclude(e => e.Country).ThenInclude(e => e.Region)
        .Include(e => e.Job)
        .AsNoTracking().ToListAsync();
      var dtoModdels = dataModels.Select(e => _Mapper.Map<DTO.Employee>(e)).ToList();
      return dtoModdels;
    }

    public async Task<List<DTO.Employee>> GetByProperty(int? id, string? firstName, string? lastName, string? email, string? departmentName, string? countryName, string? regionName)
    {
      var query = _Context.Employees.AsQueryable();

      if (id.HasValue)
      {
        query = query.Where(e => e.EmployeeId == id.Value);
      }

      if (!string.IsNullOrEmpty(firstName))
      {
        query = query.Where(e => e.FirstName.Contains(firstName));
      }

      if (!string.IsNullOrEmpty(lastName))
      {
        query = query.Where(e => e.LastName.Contains(lastName));
      }

      if (!string.IsNullOrEmpty(email))
      {
        query = query.Where(e => e.Email.Contains(email));
      }

      if (!string.IsNullOrEmpty(departmentName))
      {
        query = query.Where(e => e.Department.DepartmentName.Contains(departmentName));
      }

      if (!string.IsNullOrEmpty(countryName))
      {
        query = query.Where(e => e.Department.Location.Country.CountryName.Contains(countryName));
      }

      if (!string.IsNullOrEmpty(regionName))
      {
        query = query.Where(e => e.Department.Location.Country.Region.RegionName.Contains(regionName));
      }

      var dataModels = await _Context.Employees
        .Include(e => e.Dependents)
        .Include(e => e.Department).ThenInclude(e => e.Location).ThenInclude(e => e.Country).ThenInclude(e => e.Region)
        .Include(e => e.Job)
        .AsNoTracking().ToListAsync();
      var dtoModdels = dataModels.Select(e => _Mapper.Map<DTO.Employee>(e)).ToList();
      return dtoModdels;
    }
  }
}
