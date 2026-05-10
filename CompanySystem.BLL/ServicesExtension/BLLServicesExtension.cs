using Microsoft.Extensions.DependencyInjection;

namespace CompanySystem.BLL
{
    public static class BLLServicesExtension
    {
        public static void AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IDepartmentManager, DepartmentManager>();
        }
    }
}
