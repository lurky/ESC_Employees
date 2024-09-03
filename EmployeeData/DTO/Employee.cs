namespace EmployeeData.DTO
{
  public class Employee
  {

    public Employee() { }

    public int? EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly? HireDate { get; set; }
    public virtual Department? Department { get; set; }
    public virtual ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();
    public virtual Job? Job { get; set; }
    public string? FullName { get { return $"{FirstName} {LastName}"; } }
  }
}