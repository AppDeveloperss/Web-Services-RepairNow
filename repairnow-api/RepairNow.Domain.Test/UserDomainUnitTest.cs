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

    //[Test]
    //public void Sum_ReturnSum()
    //{
    //    ///AAA
    //    int number1 = 10;
    //    int number2 = 20;
    //    var testableDomain = new TestableDomain();
//
    //    var valorEsperado = 30;
    //    
    //    //Act
    //    var returnValue=testableDomain.sum(number1, number2);
//
    //    //Asert
    //    Assert.AreEqual(valorEsperado,returnValue);
    //    
//
    //    ////arrange-> Preparar los datos
    //    //var userDomain = new UsersDomain();
    //    //var user = new User();
    //    //user.email = "emaildepruebahotmail.com";
    //    //
    //    ////act-> Ejecutamos funcion
    //    //var result = userDomain.createUser(user);
    //    //
    //    //
    //    ////assert.> Comparamos
    //    //Assert.Equals(Exception, result);
//
    //    //Assert.Pass();
    //}

    [Theory]
    [InlineData(1,1,1)]
    [InlineData(2,2,4)]
    [InlineData(3,3,9)]
    public void Mul_ReturnMul(int number1,int number2,int expectedValue)
    {
        var testableDomain = new TestableDomain();
        var returnValue=testableDomain.multiply(number1, number2);
        Assert.Equal(expectedValue,returnValue);
        //Assert.That(result,is.Equal(expected));
    }

    [Fact]
    public void CreateUser_ReturnTrue()
    {
        ///AAA
        //Arrange
        //Mock al ICategoryRepository, una instancia falsa(un mock)
        var usersRepository = new Mock<IUsersRepository>();
        usersRepository.Setup(usersRepository => usersRepository.createUser(It.IsAny<User>())).Returns(Task.FromResult(true));

        //var expectedValue = Task.FromResult(true);
        
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
        
        //Act

        var result = userDomain.createUser(user);
        
        //Assert
        //Assert.Equal(expectedValue,result);
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