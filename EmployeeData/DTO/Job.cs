namespace EmployeeData.DTO
{
  public class Job
  {
    public Job() { }
    public int? JobId { get; set; }
    public string? JobTitle { get; set; }
    public decimal? MinSalary { get; set; }
    public decimal? MaxSalary { get; set; }
  }
}
