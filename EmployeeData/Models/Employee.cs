namespace EmployeeData.Models;

public partial class Employee
{
  public int EmployeeId { get; set; }

  public string? FirstName { get; set; }

  public string LastName { get; set; } = null!;

  public string Email { get; set; } = null!;

  public string? PhoneNumber { get; set; }

  public DateOnly HireDate { get; set; }

  public int JobId { get; set; }

  public decimal Salary { get; set; }

  public int? ManagerId { get; set; }

  public int? DepartmentId { get; set; }

  public virtual Department? Department { get; set; }

  public virtual ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();

  public virtual Job Job { get; set; } = null!;
}
