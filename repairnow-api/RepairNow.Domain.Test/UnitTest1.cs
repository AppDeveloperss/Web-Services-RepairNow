using RepairNow.Infraestructure;

namespace RepairNow.Domain.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        
        //arrange-> Preparar los datos
        var userDomain = new UsersDomain();
        var user = new User();
        user.email = "emaildepruebahotmail.com";
        
        //act-> Ejecutamos funcion
        var result = userDomain.createUser(user);
        
        
        //assert.> Comparamos
        Assert.Equals(Exception, result);
        
        
        
        
        Assert.Pass();
    }
}