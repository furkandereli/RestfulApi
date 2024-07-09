using RestfulApi.Services.FakeServices;
using RestfulApi.Services.StudentServices;

namespace RestfulApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void CustomServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IFakeService, FakeService>();
        }
    }
}
