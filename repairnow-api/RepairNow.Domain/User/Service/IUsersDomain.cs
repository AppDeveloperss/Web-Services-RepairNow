using RepairNow.Infraestructure;

namespace RepairNow.Domain;

public interface IUsersDomain
{
    Task<string> Login(Login user);
    Task<Boolean> Signup(User user);
    List<User> getAll();
    User getUserById(int id);
    Task<Boolean> createUser(User user);
    Task<Boolean> updateUser(int id, User user);
    Task<Boolean> deleteUser(int id);
}