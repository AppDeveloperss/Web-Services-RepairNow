namespace RepairNow.Infraestructure;

public interface IAppointmentsRepository
{
    List<Appointment> getAll();
    Appointment getAppointmentById(int id);
    Task<Boolean> createAppointment(string name);
    Boolean updateAppointment(int id, string name);
    Boolean deleteAppointment(int id);
}