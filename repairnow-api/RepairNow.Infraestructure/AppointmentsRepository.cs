using RepairNow.Infraestructure.Context;

namespace RepairNow.Infraestructure;

public class AppointmentsRepository: IAppointmentsRepository
{
    private RepairNowDB _repairNowDb;
    public AppointmentsRepository(RepairNowDB repairNowDb)
    {
        _repairNowDb = repairNowDb;
    }


    public List<Appointment> getAll()
    {
        return _repairNowDb.Appointments.Where(appointment => appointment.isActive).ToList();
    }

    public Appointment getAppointmentById(int id)
    {
        return _repairNowDb.Appointments.Find(id);
    }

    public async Task<bool> createAppointment(Appointment appointment)
    {
        
        using (var transacction = _repairNowDb.Database.BeginTransactionAsync())
        {
            try
            {
                _repairNowDb.Appointments.AddAsync(appointment);
                _repairNowDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _repairNowDb.Database.RollbackTransactionAsync();
            }
        }
        _repairNowDb.Database.CommitTransactionAsync(); 
        return true;
    }

    public async Task<bool> updateAppointment(int id, Appointment new_appointment)
    {
        using (var transacction = _repairNowDb.Database.BeginTransactionAsync())
        {
            try
            {
                //User user = _repairNowDb.Users.Find(id);
                Appointment appointment = await _repairNowDb.Appointments.FindAsync(id);

                appointment.DateUpdate = DateTime.Now;

                appointment.dateAttention = new_appointment.dateAttention;
                appointment.dateReserve = new_appointment.dateReserve;
                appointment.hour = new_appointment.hour;
                appointment.clientId = new_appointment.clientId;
                appointment.applianceModelId = new_appointment.applianceModelId;

                _repairNowDb.Appointments.Update(appointment);
                _repairNowDb.SaveChanges();
            }
            catch (Exception ex)
            {
                _repairNowDb.Database.RollbackTransactionAsync();
            }
        }
        
        _repairNowDb.Database.CommitTransactionAsync(); 
        return true;
    }
    
    public bool updateAppointment(int id)
    {
        throw new NotImplementedException();
    }
    
    public bool deleteAppointment(int id)
    {
        throw new NotImplementedException();
    }
}