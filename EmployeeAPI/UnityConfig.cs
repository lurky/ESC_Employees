using EmployeeData.Repos;
using Unity;
using EmployeeData.Contracts;
using AutoMapper;

namespace EmployeeApi
{
  public static class UnityConfig
  {
    public static IUnityContainer RegisterComponents()
    {
      var container = new UnityContainer();

      // Register your types here
      
      container.RegisterType<IEmployeeRepo, EmployeeRepo>();
      var mapper = AutoMapperConfig.Configure();
      container.RegisterInstance<IMapper>(mapper);

      return container;
    }
  }
}