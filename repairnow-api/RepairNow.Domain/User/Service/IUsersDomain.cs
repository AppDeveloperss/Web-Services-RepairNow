using RepairNow.Infraestructure;
using RepairNowAPI.Response;

namespace RepairNow.Domain;

public interface IUsersDomain
{
    Task<AutenthicateResponse> Login(Login user);
    Task<Boolean> Signup(User user);
    List<User> getAll();
    Task<User> getByEmail(string email);
    User getUserById(int id);
    Task<Boolean> createUser(User user);
    Task<Boolean> updateUser(int id, User user);
    Task<Boolean> deleteUser(int id);
}