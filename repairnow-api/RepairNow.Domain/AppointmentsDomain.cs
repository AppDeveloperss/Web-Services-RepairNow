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

    public async Task<bool> createAppointment(Appointment appointment)
    {
        return await _appointmentsRepository.createAppointment(appointment);
    }

    public async Task<bool> updateAppointment(int id, Appointment appointment)
    {
        return await _appointmentsRepository.updateAppointment(id, appointment);
    }

    public bool deleteAppointment(int id)
    {
        return _appointmentsRepository.deleteAppointment(id);
    }
}