using System.Security;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualBasic;
using RepairNow.Domain.Test;
using RepairNow.Infraestructure;
using RepairNow.Shared;

namespace RepairNow.Domain;
//Aquí se hace la lógica del negocio
public class UsersDomain:IUsersDomain
{
    //Instanciamos una variable en la interfaz
    private IUsersRepository _usersRepository;

    private readonly ITokenDomain _tokenDomain;
    //luego en el constructor de esta clase le pasamos ese parametro
    public UsersDomain(IUsersRepository usersRepository,ITokenDomain tokenDomain)
    {
        _usersRepository = usersRepository;
        _tokenDomain = tokenDomain;
    }

    public async Task<string> Login(Login user)
    {
        var result = await _usersRepository.GetByEmail(user.email);
        if (result.password == user.password)
        {
            return _tokenDomain.GenerateJwt(user.email);
        }

        throw new ArgumentException("Invalid username or password");
    }

    public async Task<bool> Signup(User user)
    {
        return await _usersRepository.Signup(user);
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
            throw new VerificationException("Invalid Email");
        }

        if (user.phone.Length != 9)
        {
            throw new VerificationException("Invalid Phone Number");
        }

        if (user.type == "technician" && user.plan != null)
        {
            throw new VerificationException("Technician Plan Invalid");
        }
        
        return await _usersRepository.createUser(user);
    }
    public async Task<bool> updateUser(int id, User user)
    {
        if (!user.email.Contains((char)Constans.valueContainedsEmail))
        {
            throw new VerificationException("Invalid Email");
        }

        if (user.phone.Length != 9)
        {
            throw new VerificationException("Invalid Phone Number");
        }

        if (user.type == "technician" && user.plan != null)
        {
            throw new VerificationException("Technician Plan Invalid");
        }
        
        return await _usersRepository.updateUser(id, user);
    }

    public async Task<bool> deleteUser(int id)
    {
        return await _usersRepository.deleteUser(id);
    }
}