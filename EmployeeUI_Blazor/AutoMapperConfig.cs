using AutoMapper;
using DTO = EmployeeData.DTO;
using EmployeeData.Models;

namespace EmployeeUI_Blazor
{
  public class AutoMapperConfig
  {
    public static IMapper Configure()
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<Employee, DTO.Employee>()
                  .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                  .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                  .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                  .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                  .ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => src.HireDate))
                  .ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.Job))
                  .ForMember(dest => dest.Dependents, opt => opt.MapFrom(src => src.Dependents))
                  .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department));

        cfg.CreateMap<Department, DTO.Department>()
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DepartmentName))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));


        cfg.CreateMap<Country, DTO.Country>()
            .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.CountryName))
            .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region));

        cfg.CreateMap<Region, DTO.Region>()
            .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.RegionId))
            .ForMember(dest => dest.RegionName, opt => opt.MapFrom(src => src.RegionName));

        cfg.CreateMap<Dependent, DTO.Dependent>()
            .ForMember(dest => dest.DependentId, opt => opt.MapFrom(src => src.DependentId))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Relationship, opt => opt.MapFrom(src => src.Relationship));

        cfg.CreateMap<Job, DTO.Job>()
          .ForMember(dest => dest.JobId, opt => opt.MapFrom(src => src.JobId))
          .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
          .ForMember(dest => dest.MinSalary, opt => opt.MapFrom(src => src.MinSalary))
          .ForMember(dest => dest.MaxSalary, opt => opt.MapFrom(src => src.MaxSalary));

        cfg.CreateMap<Location, DTO.Location>()
          .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.LocationId))
            .ForMember(dest => dest.StreetAddress, opt => opt.MapFrom(src => src.StreetAddress))
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.StateProvince, opt => opt.MapFrom(src => src.StateProvince))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
      });

      return config.CreateMapper();
    }
  }
}
