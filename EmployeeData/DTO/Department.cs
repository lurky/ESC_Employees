namespace EmployeeData.DTO
{
  public class Department
  {
    public Department() { }
    public int? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public virtual Location? Location { get; set; }
  }
}