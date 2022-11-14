using RepairNow.Infraestructure;

namespace RepairNow.Domain;
//Aquí se hace la lógica del negocio
public class UsersDomain:IUsersDomain
{
    //Instanciamos una variable en la interfaz
    private IUsersRepository _usersRepository;
    //luego en el constructor de esta clase le pasamos ese parametro
    public UsersDomain(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public List<User> getAll()
    {
        return _usersRepository.getAll();
    }

    public User getUserById(int id)
    {
        return _usersRepository.getUserById(id);
    }

    public async Task<bool> createUser(User user)
    {
        return await _usersRepository.createUser(user);
    }

    public async Task<bool> updateUser(int id, User user)
    {
        return await _usersRepository.updateUser(id, user);
    }

    public bool deleteUser(int id)
    {
        return _usersRepository.deleteUser(id);
    }
}