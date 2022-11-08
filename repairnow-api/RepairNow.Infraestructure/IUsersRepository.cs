namespace RepairNow.Infraestructure;

public interface IUsersRepository
{
    List<User> getAll();
    User getUserById(int id);
    Task<Boolean> createUser(string name);

    Boolean updateUser(int id, string name);
    Boolean deleteUser(int id);
}
