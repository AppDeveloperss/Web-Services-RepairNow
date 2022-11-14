using RepairNow.Infraestructure;

namespace RepairNow.Domain;

public interface IUsersDomain
{
    List<User> getAll();
    User getUserById(int id);
    Task<Boolean> createUser(User user);
    Boolean updateUser(int id, string name);
    Boolean deleteUser(int id);
}