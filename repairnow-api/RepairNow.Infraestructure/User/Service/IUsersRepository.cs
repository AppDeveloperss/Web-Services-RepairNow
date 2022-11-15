namespace RepairNow.Infraestructure;

public interface IUsersRepository
{
    List<User> getAll();
    User getUserById(int id);
    Task<Boolean> createUser(User user);

    Task<Boolean> updateUser(int id, User user);
    Task<Boolean> deleteUser(int id);
}
