using RestfulApi.BusinessLayer.Abstract;
using RestfulApi.BusinessLayer.Concrete;

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
