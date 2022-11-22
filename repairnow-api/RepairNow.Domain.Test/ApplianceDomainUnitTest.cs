using Moq;
using RepairNow.Infraestructure;
using Xunit;

namespace RepairNow.Domain.Test;

public class ApplianceDomainUnitTest
{
    [Fact]
    public void Setup()
    {
    }
    
    [Fact]
    public void CreateAppliance_ReturnTrue()
    {
        var appliancesRepository = new Mock<IAppliancesRepository>();
        appliancesRepository.Setup(appliancesRepository => appliancesRepository.createAppliance(It.IsAny<Appliance>())).Returns(Task.FromResult(true));

        var appliance = new Appliance()
        {
            name = "Freezer",
            description = "Bug Freezer",
            brand = "LG",
            model = "MK-32",
            year = 2021,
            urlImage = "inserte_url",
            insuranceDate = "25/08/10",
            clientId = 1,
        };
        var applianceDomain = new AppliancesDomain(appliancesRepository.Object);
        var result = applianceDomain.createAppliance(appliance);
        Assert.True(result.Result);
    }
    
    [Fact]
    public void UpdateAppliance_ReturnTrue()
    {
        var appliancesRepository = new Mock<IAppliancesRepository>();
        appliancesRepository.Setup(appliancesRepository => appliancesRepository.updateAppliance(1,It.IsAny<Appliance>())).Returns(Task.FromResult(true));
        
        var oldAppliance = new Appliance()
        {
            id = 1,
            name = "Freezer",
            description = "Bug Freezer",
            brand = "LG",
            model = "MK-32",
            year = 2021,
            urlImage = "inserte_url",
            insuranceDate = "25/08/10",
            clientId = 1,
        };
        var newAppliance = new Appliance()
        {
            name = "Washing Machine",
            description = "Fixed",
            brand = "SAMSUNG",
            model = "MK-32",
            year = 2021,
            urlImage = "inserte_url",
            insuranceDate = "25/08/10",
            clientId = 1,
        };
        var applianceDomain = new AppliancesDomain(appliancesRepository.Object);
        var createResult = applianceDomain.createAppliance(oldAppliance);
        var updateResult = applianceDomain.updateAppliance(1,newAppliance);

        Assert.True(updateResult.Result);
    }

}