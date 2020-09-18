using System.Collections.Generic;
using Products.API.Model;
using Products.API.ViewModel;

namespace Products.API.Service
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
