namespace EmployeeData.DTO
{
  public class Location
  {
    public Location() { }
    public int? LocationId { get; set; }
    public string? City { get; set; }
    public string? StateProvince { get; set; }
    public string? StreetAddress { get; set; }
    public string? PostalCode { get; set; }
    public virtual Country? Country { get; set; }
  }
}
