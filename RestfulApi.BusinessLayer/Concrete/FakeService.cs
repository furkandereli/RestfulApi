using RestfulApi.BusinessLayer.Abstract;
using RestfulApi.EntityLayer.Entities;

namespace RestfulApi.BusinessLayer.Concrete
{
    public class FakeService : IFakeService
    {
        private readonly List<FakeUser> _users = new List<FakeUser>
        {
            new FakeUser { Username = "fakeUser", Password = "fakePassword"}
        };

        public FakeUser Authenticate(string username, string password)
        {
            return _users.SingleOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
