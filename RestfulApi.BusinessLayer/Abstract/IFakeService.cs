using RestfulApi.EntityLayer.Entities;

namespace RestfulApi.BusinessLayer.Abstract
{
    public interface IFakeService
    {
        FakeUser Authenticate(string username, string password);
    }
}
