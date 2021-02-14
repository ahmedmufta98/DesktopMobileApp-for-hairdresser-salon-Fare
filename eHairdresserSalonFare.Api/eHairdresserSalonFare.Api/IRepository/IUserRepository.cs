using eHairdresserSalonFare.Model.Requests.User;
using System.Collections.Generic;

namespace eHairdresserSalonFare.Api.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<Model.User> Get(UserSearchRequest search);
        Model.User GetById(int id);
        Model.User Insert(UserUpsertRequest request);
        Model.User Update(int id, UserUpsertRequest request);
        Model.User Delete(int id);
        Model.User Login(UserLoginRequest request);
        Model.User Register(UserUpsertRequest request);
        Model.User Authenticate(string username, string password);
    }
}
