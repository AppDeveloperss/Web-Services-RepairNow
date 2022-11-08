using RepairNow.Infraestructure;

namespace RepairNow.Domain;

public class AppointmentsDomain:IAppointmentsDomain
{
    
    private IAppointmentsRepository _appointmentsRepository;

    public AppointmentsDomain(IAppointmentsRepository appointmentsRepository)
    {
        _appointmentsRepository = appointmentsRepository;
    }
    
    
    public List<Appointment> getAll()
    {
        return _appointmentsRepository.getAll();
    }

    public Appointment getAppointmentById(int id)
    {
        return _appointmentsRepository.getAppointmentById(id);
    }

    public Task<bool> createAppointment(string name)
    {
        return _appointmentsRepository.createAppointment(name);
    }

    public bool updateAppointment(int id, string name)
    {
        return _appointmentsRepository.updateAppointment(id, name);
    }

    public bool deleteAppointment(int id)
    {
        return _appointmentsRepository.deleteAppointment(id);
    }
}