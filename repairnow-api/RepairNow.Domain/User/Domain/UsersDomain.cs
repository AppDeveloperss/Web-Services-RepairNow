using System.Security;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualBasic;
using RepairNow.Infraestructure;
using RepairNow.Shared;

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
        return  _usersRepository.getUserById(id);
    }
    public async Task<bool> createUser(User user)
    {
        if (!user.email.Contains((char)Constans.valueContainedsEmail))
        {
            throw new VerificationException("Email no válido");
        }
        return await _usersRepository.createUser(user);
    }
    public async Task<bool> updateUser(int id, User user)
    {
        return await _usersRepository.updateUser(id, user);
    }

    public async Task<bool> deleteUser(int id)
    {
        return await _usersRepository.deleteUser(id);
    }
}