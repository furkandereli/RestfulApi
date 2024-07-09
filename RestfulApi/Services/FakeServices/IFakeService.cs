using RestfulApi.Entities;

namespace RestfulApi.Services.FakeServices
{
    public interface IFakeService
    {
        FakeUser Authenticate(string username, string password);
    }
}
