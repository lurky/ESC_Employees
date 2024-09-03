using Microsoft.EntityFrameworkCore;
using EmployeeData.Models;
namespace EmployeeData;

public partial class MasterContext : DbContext
{
  //In a production application, this connection string should be stored in a secure location.
  private readonly string _connectionString = "";
  public MasterContext()
  {
  }


  public MasterContext(DbContextOptions<MasterContext> options)
      : base(options)
  {
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(_connectionString);
  }
  public virtual DbSet<Country> Countries { get; set; }
  public virtual DbSet<Department> Departments { get; set; }
  public virtual DbSet<Dependent> Dependents { get; set; }
  public virtual DbSet<Employee> Employees { get; set; }
  public virtual DbSet<Job> Jobs { get; set; }
  public virtual DbSet<Location> Locations { get; set; }

  public virtual DbSet<Region> Regions { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Country>(entity =>
    {
      entity.HasKey(e => e.CountryId).HasName("PK__countrie__7E8CD0551339CCC3");

      entity.ToTable("countries");

      entity.Property(e => e.CountryId)
              .HasMaxLength(2)
              .IsUnicode(false)
              .IsFixedLength()
              .HasColumnName("country_id");
      entity.Property(e => e.CountryName)
              .HasMaxLength(40)
              .IsUnicode(false)
              .HasDefaultValueSql("(NULL)")
              .HasColumnName("country_name");
      entity.Property(e => e.RegionId).HasColumnName("region_id");

      entity.HasOne(d => d.Region).WithMany(p => p.Countries)
              .HasForeignKey(d => d.RegionId)
              .HasConstraintName("FK__countries__regio__297722B6");
    });

    modelBuilder.Entity<Department>(entity =>
    {
      entity.HasKey(e => e.DepartmentId).HasName("PK__departme__C22324228749F29A");

      entity.ToTable("departments");

      entity.Property(e => e.DepartmentId).HasColumnName("department_id");
      entity.Property(e => e.DepartmentName)
              .HasMaxLength(30)
              .IsUnicode(false)
              .HasColumnName("department_name");
      entity.Property(e => e.LocationId)
              .HasDefaultValueSql("(NULL)")
              .HasColumnName("location_id");

      entity.HasOne(d => d.Location).WithMany(p => p.Departments)
              .HasForeignKey(d => d.LocationId)
              .OnDelete(DeleteBehavior.Cascade)
              .HasConstraintName("FK__departmen__locat__36D11DD4");
    });

    modelBuilder.Entity<Dependent>(entity =>
    {
      entity.HasKey(e => e.DependentId).HasName("PK__dependen__F25E28CECAFA42B4");

      entity.ToTable("dependents");

      entity.Property(e => e.DependentId).HasColumnName("dependent_id");
      entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
      entity.Property(e => e.FirstName)
              .HasMaxLength(50)
              .IsUnicode(false)
              .HasColumnName("first_name");
      entity.Property(e => e.LastName)
              .HasMaxLength(50)
              .IsUnicode(false)
              .HasColumnName("last_name");
      entity.Property(e => e.Relationship)
              .HasMaxLength(25)
              .IsUnicode(false)
              .HasColumnName("relationship");

      entity.HasOne(d => d.Employee).WithMany(p => p.Dependents)
              .HasForeignKey(d => d.EmployeeId)
              .HasConstraintName("FK__dependent__emplo__4242D080");
    });

    modelBuilder.Entity<Employee>(entity =>
    {
      entity.HasKey(e => e.EmployeeId).HasName("PK__employee__C52E0BA8DDC1BF28");

      entity.ToTable("employees");

      entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
      entity.Property(e => e.DepartmentId)
              .HasDefaultValueSql("(NULL)")
              .HasColumnName("department_id");
      entity.Property(e => e.Email)
              .HasMaxLength(100)
              .IsUnicode(false)
              .HasColumnName("email");
      entity.Property(e => e.FirstName)
              .HasMaxLength(20)
              .IsUnicode(false)
              .HasDefaultValueSql("(NULL)")
              .HasColumnName("first_name");
      entity.Property(e => e.HireDate).HasColumnName("hire_date");
      entity.Property(e => e.JobId).HasColumnName("job_id");
      entity.Property(e => e.LastName)
              .HasMaxLength(25)
              .IsUnicode(false)
              .HasColumnName("last_name");
      entity.Property(e => e.ManagerId)
              .HasDefaultValueSql("(NULL)")
              .HasColumnName("manager_id");
      entity.Property(e => e.PhoneNumber)
              .HasMaxLength(20)
              .IsUnicode(false)
              .HasDefaultValueSql("(NULL)")
              .HasColumnName("phone_number");
      entity.Property(e => e.Salary)
              .HasColumnType("decimal(8, 2)")
              .HasColumnName("salary");

      entity.HasOne(d => d.Department).WithMany(p => p.Employees)
              .HasForeignKey(d => d.DepartmentId)
              .OnDelete(DeleteBehavior.Cascade)
              .HasConstraintName("FK__employees__depar__3E723F9C");

      entity.HasOne(d => d.Job).WithMany(p => p.Employees)
              .HasForeignKey(d => d.JobId)
              .HasConstraintName("FK__employees__job_i__3D7E1B63");
    });

    modelBuilder.Entity<Job>(entity =>
    {
      entity.HasKey(e => e.JobId).HasName("PK__jobs__6E32B6A591D2C53B");

      entity.ToTable("jobs");

      entity.Property(e => e.JobId).HasColumnName("job_id");
      entity.Property(e => e.JobTitle)
              .HasMaxLength(35)
              .IsUnicode(false)
              .HasColumnName("job_title");
      entity.Property(e => e.MaxSalary)
              .HasDefaultValueSql("(NULL)")
              .HasColumnType("decimal(8, 2)")
              .HasColumnName("max_salary");
      entity.Property(e => e.MinSalary)
              .HasDefaultValueSql("(NULL)")
              .HasColumnType("decimal(8, 2)")
              .HasColumnName("min_salary");
    });

    modelBuilder.Entity<Location>(entity =>
    {
      entity.HasKey(e => e.LocationId).HasName("PK__location__771831EAE57CDD0B");

      entity.ToTable("locations");

      entity.Property(e => e.LocationId).HasColumnName("location_id");
      entity.Property(e => e.City)
              .HasMaxLength(30)
              .IsUnicode(false)
              .HasColumnName("city");
      entity.Property(e => e.CountryId)
              .HasMaxLength(2)
              .IsUnicode(false)
              .IsFixedLength()
              .HasColumnName("country_id");
      entity.Property(e => e.PostalCode)
              .HasMaxLength(12)
              .IsUnicode(false)
              .HasDefaultValueSql("(NULL)")
              .HasColumnName("postal_code");
      entity.Property(e => e.StateProvince)
              .HasMaxLength(25)
              .IsUnicode(false)
              .HasDefaultValueSql("(NULL)")
              .HasColumnName("state_province");
      entity.Property(e => e.StreetAddress)
              .HasMaxLength(40)
              .IsUnicode(false)
              .HasDefaultValueSql("(NULL)")
              .HasColumnName("street_address");

      entity.HasOne(d => d.Country).WithMany(p => p.Locations)
              .HasForeignKey(d => d.CountryId)
              .HasConstraintName("FK__locations__count__2F2FFC0C");
    });

    modelBuilder.Entity<Region>(entity =>
    {
      entity.HasKey(e => e.RegionId).HasName("PK__regions__01146BAEB0D13B04");

      entity.ToTable("regions");

      entity.Property(e => e.RegionId).HasColumnName("region_id");
      entity.Property(e => e.RegionName)
              .HasMaxLength(25)
              .IsUnicode(false)
              .HasDefaultValueSql("(NULL)")
              .HasColumnName("region_name");
    });

    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
