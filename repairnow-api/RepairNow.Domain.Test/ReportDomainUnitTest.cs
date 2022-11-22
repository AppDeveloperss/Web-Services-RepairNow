using Moq;
using RepairNow.Infraestructure;
using Xunit;

namespace RepairNow.Domain.Test;

public class ReportDomainUnitTest
{
    [Fact]
    public void Setup()
    {
    }
    
    [Fact]
    public void CreateReport_ReturnTrue()
    {
        var reportsRepository = new Mock<IReportsRepository>();
        reportsRepository.Setup(appointmentsRepository => appointmentsRepository.createReport(It.IsAny<Report>())).Returns(Task.FromResult(true));

        var report = new Report()
        {
            id=1,
            observation="Circuit burned",
            diagnosis="An internal circuit of the refrigerator has burned out due to excessive use.",
            repairDescription ="I soldered the burned circuit",
            date="21/5/2022",
            technicianId =3,
        };
        var reportDomain = new ReportsDomain(reportsRepository.Object);
        var result = reportDomain.createReport(report);
        Assert.True(result.Result);
    }
    
    [Fact]
    public void UpdateReport_ReturnTrue()
    {
        var reportsRepository = new Mock<IReportsRepository>();
        reportsRepository.Setup(appointmentsRepository => appointmentsRepository.updateReport(1,It.IsAny<Report>())).Returns(Task.FromResult(true));

        
        var oldReport = new Report()
        {
            id=1,
            observation="Circuit burned",
            diagnosis="An internal circuit of the refrigerator has burned out due to excessive use.",
            repairDescription ="I soldered the burned circuit",
            date="21/5/2022",
            technicianId =3,
        };
        var newReport = new Report()
        {
            observation="Nothin Observation",
            diagnosis="Just a insect inside appliance.",
            repairDescription ="Only clean the appliance",
            date="21/5/2022",
            technicianId =3,
        };
        var reportDomain = new ReportsDomain(reportsRepository.Object);
        var createResult = reportDomain.createReport(oldReport);
        var updateResult = reportDomain.updateReport(1,newReport);

        Assert.True(updateResult.Result);
    }
}