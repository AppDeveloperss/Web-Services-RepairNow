using Microsoft.EntityFrameworkCore;
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
    
    //public async Task<bool> createReport(Report report)
    //{
    //    
    //    using (var transacction = _repairNowDb.Database.BeginTransactionAsync())
    //    {
    //        try
    //        {
    //            await _repairNowDb.Reports.AddAsync(report);
    //            _repairNowDb.SaveChanges();
    //        }
    //        catch (Exception ex)
    //        {
    //            _repairNowDb.Database.RollbackTransactionAsync();
    //        }
    //    }
    //    _repairNowDb.Database.CommitTransactionAsync();
    //    return true;
    //}
    
    public async Task<bool> createReport(Report report)
    {        
        var strategy = _repairNowDb.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using (var transacction = await _repairNowDb.Database.BeginTransactionAsync())
            {
                try
                {
                    await _repairNowDb.Reports.AddAsync(report);
                    await _repairNowDb.SaveChangesAsync();
                    await transacction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await _repairNowDb.Database.RollbackTransactionAsync();
                }
            }
        });
        return true;
    }
    public async Task<bool> updateReport(int id, Report new_report)
    {
        using (var transacction = _repairNowDb.Database.BeginTransactionAsync())
        {
            try
            {
                Report report = await _repairNowDb.Reports.FindAsync(id);

                report.DateUpdate = DateTime.Now;

                report.observation = new_report.observation;
                report.diagnosis = new_report.diagnosis;
                report.repairDescription = new_report.repairDescription;
                report.date = new_report.date;
                report.technicianId = new_report.id;

                _repairNowDb.Reports.Update(report);
                _repairNowDb.SaveChanges();
                await _repairNowDb.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                _repairNowDb.Database.RollbackTransactionAsync();
            }
        }
        return true;
    }
    public async Task<bool> deleteReport(int id)
    {
        using (var transacction = _repairNowDb.Database.BeginTransactionAsync())
        {
            try
            {
                Report report = await _repairNowDb.Reports.FindAsync(id);
                report.isActive = false;
                report.DateUpdate=DateTime.Now;
                _repairNowDb.Reports.Update(report);
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
}