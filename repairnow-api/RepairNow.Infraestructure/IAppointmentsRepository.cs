namespace RepairNow.Infraestructure;

public interface IAppointmentsRepository
{
    List<Appointment> getAll();
    Appointment getAppointmentById(int id);
    Task<Boolean> createAppointment(Appointment appointment);
    Task<Boolean> updateAppointment(int id, Appointment appointment);
    Boolean deleteAppointment(int id);
}