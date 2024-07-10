using FluentValidation.AspNetCore;
using RestfulApi.BusinessLayer.Abstract;
using RestfulApi.BusinessLayer.Concrete;
using System.Reflection;

namespace RestfulApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void CustomServices(this IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson()
                    .AddFluentValidation(v => v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IFakeService, FakeService>();
            services.AddScoped<ILanguageService, LanguageService>();
        }
    }
}
