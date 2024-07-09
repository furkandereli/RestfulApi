using RestfulApi.Services.FakeServices;

namespace RestfulApi.Middlewares
{
    public class FakeAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public FakeAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IFakeService fakeService)
        {
            var username = context.Request.Headers["Username"].FirstOrDefault();
            var password = context.Request.Headers["Password"].FirstOrDefault();

            if (username != null && password != null)
            {
                var user = fakeService.Authenticate(username, password);
                if (user != null)
                {
                    context.Items["User"] = user;
                }
            }

            await _next(context);
        }
    }
}
