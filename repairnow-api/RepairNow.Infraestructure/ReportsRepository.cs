using RepairNow.Infraestructure.Context;

namespace RepairNow.Infraestructure;

public class ReportsRepository:IReportsRepository
{
    private RepairNowDB _repairNowDb;

    public ReportsRepository(RepairNowDB repairNowDb)
    {
        _repairNowDb = repairNowDb;
    }
    
    public List<Report> getAll()
    {
        return _repairNowDb.Reports.Where(report=>report.isActive).ToList(); 
    }

    public Report getReportById(int id)
    {
        return _repairNowDb.Reports.Find(id);
    }

    public async Task<bool> createReport(string name)
    {
        Report report = new Report();
        report.diagnosis = name;
        
        //TRANSACCION solo para insert, updated, delete , para lectura no hay transacciones
        _repairNowDb.Database.BeginTransactionAsync();

        try
        {
            _repairNowDb.Reports.AddAsync(report);
            _repairNowDb.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _repairNowDb.Database.RollbackTransactionAsync();//Si pasa algo malo entonces lo anula(hace rollback)
        }
        
        _repairNowDb.Database.CommitTransactionAsync(); //Si no pasa algo malo entonces good
        return true;
    }

    public bool updateReport(int id, string name)
    {
        Report report = _repairNowDb.Reports.Find(id);

        report.diagnosis= name;
        report.DateUpdate=DateTime.Now;
        
        _repairNowDb.Reports.Update(report);
        _repairNowDb.SaveChanges();

        return true;
    }

    public bool deleteReport(int id)
    {
        Report report = _repairNowDb.Reports.Find(id);

        //_repairNowDb.Users.Remove(user);
        //_repairNowDb.SaveChanges();

        report.isActive = false;
        report.DateUpdate=DateTime.Now;
        _repairNowDb.Reports.Update(report);
        _repairNowDb.SaveChanges();
        return true;
    }
}