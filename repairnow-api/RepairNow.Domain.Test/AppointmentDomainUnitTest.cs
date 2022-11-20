using Moq;
using RepairNow.Infraestructure;
using Xunit;

namespace RepairNow.Domain.Test;

public class AppointmentDomainUnitTest
{
    [Fact]
    public void Setup()
    {
    }
    
    [Fact]
    public void CreateAppointment_ReturnTrue()
    {
        var appointmentsRepository = new Mock<IAppointmentsRepository>();
        appointmentsRepository.Setup(appointmentsRepository => appointmentsRepository.createAppointment(It.IsAny<Appointment>())).Returns(Task.FromResult(true));

        var appointment = new Appointment()
        {
            dateReserve="19/10/22",
            dateAttention="22/09/2022",
            hour = "02:20",
            clientId =1,
            applianceModelId =1,
        };
        var appointmentDomain = new AppointmentsDomain(appointmentsRepository.Object);
        var result = appointmentDomain.createAppointment(appointment);
        Assert.True(result.Result);
    }
    
    [Fact]
    public void UpdateAppointment_ReturnTrue()
    {
        var appointmentsRepository = new Mock<IAppointmentsRepository>();
        appointmentsRepository.Setup(appointmentsRepository => appointmentsRepository.updateAppointment(1,It.IsAny<Appointment>())).Returns(Task.FromResult(true));

        
        var oldAppointment = new Appointment()
        {
            id = 1,
            dateReserve="19/10/22",
            dateAttention="22/09/2022",
            hour = "02:20",
            applianceModelId =1,
            clientId = 1,
        };
        var newAppointment = new Appointment()
        {
            dateReserve="10/10/22",
            dateAttention="05/11/2022",
            hour = "05:50",
            applianceModelId =1,
            clientId = 1,
        };
        var appointmentDomain = new AppointmentsDomain(appointmentsRepository.Object);
        var createResult = appointmentDomain.createAppointment(oldAppointment);
        var updateResult = appointmentDomain.updateAppointment(1,newAppointment);

        Assert.True(updateResult.Result);
    }
}