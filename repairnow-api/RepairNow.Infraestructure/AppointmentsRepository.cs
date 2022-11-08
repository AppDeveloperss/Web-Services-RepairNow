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
        //Single or default devuelve solo un elemento mientras que el ToList devuelve una lista
        //  return _repairNowDb.Users
        //    .Include(user => user.Tutorials)
        //    .SingleOrDefault(user=>user.id==id)
    }

    public async Task<bool> createAppointment(string name)
    {
        Appointment appointment = new Appointment();
        appointment.hour=name;
        
        _repairNowDb.Database.BeginTransactionAsync();
        try
        {
            _repairNowDb.Appointments.AddAsync(appointment);
            _repairNowDb.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _repairNowDb.Database.RollbackTransactionAsync();//Si pasa algo malo entonces lo anula(hace rollback)
        }
        _repairNowDb.Database.CommitTransactionAsync(); //Si no pasa algo malo entonces good
        return true;
    }

    public bool updateAppointment(int id, string name)
    {
        throw new NotImplementedException();
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