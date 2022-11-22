namespace RepairNow.Infraestructure;

public interface IUsersRepository
{
    Task<User> GetByEmail(string email);
    Task<Boolean> Login(User user);
    Task<Boolean> Signup(User user);
    List<User> getAll();
    User getUserById(int id);
    Task<Boolean> createUser(User user);

    Task<Boolean> updateUser(int id, User user);
    Task<Boolean> deleteUser(int id);
}
