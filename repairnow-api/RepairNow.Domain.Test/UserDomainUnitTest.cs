using Moq;
using RepairNow.Infraestructure;
using Xunit;

namespace RepairNow.Domain.Test;

public class Tests
{
    [Fact]
    public void Setup()
    {
    }
    
    [Fact]
    public void CreateUser_ReturnTrue()
    {
        var usersRepository = new Mock<IUsersRepository>();
        usersRepository.Setup(usersRepository => usersRepository.createUser(It.IsAny<User>())).Returns(Task.FromResult(true));

        var user = new User()
        {
            firstName="Alonso",
            lastName="Guerra",
            email="sada@gmail.com" ,
            password= "alonsoguerra",
            address="Av.Palmeras" ,
            phone="923192832" ,
            type= "client",
            plan= "monthly"
        };
        var userDomain = new UsersDomain(usersRepository.Object);
        var result = userDomain.createUser(user);
        Assert.True(result.Result);
    }
    
    [Fact]
    public void UpdateUser_ReturnTrue()
    {
        var usersRepository = new Mock<IUsersRepository>();
        usersRepository.Setup(usersRepository => usersRepository.updateUser(1,It.IsAny<User>())).Returns(Task.FromResult(true));
        
        var OldUser = new User()
        {
            id = 1,
            firstName="Alonso",
            lastName="Guerra",
            email="sada@gmail.com" ,
            password= "alonsoguerra",
            address="Av.Palmeras" ,
            phone="923192832" ,
            type= "client",
            plan= "monthly"
        };
        var newUser = new User()
        {
            firstName="Francisco",
            lastName="Rojas",
            email="francisco@gmail.com" ,
            password= "fasd",
            address="Av.Cito" ,
            phone="982312212" ,
            type= "client",
            plan= "monthly"
        };
        var userDomain = new UsersDomain(usersRepository.Object);
        var createResult = userDomain.createUser(OldUser);
        var updateResult = userDomain.updateUser(1,newUser);

        Assert.True(updateResult.Result);
    }


}