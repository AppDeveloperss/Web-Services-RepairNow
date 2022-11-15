using RepairNow.Infraestructure;

namespace RepairNow.Domain;

public interface IReportsDomain
{
    List<Report> getAll();
    Report getReportById(int id);
    Task<Boolean> createReport(Report report);
    Task<Boolean> updateReport(int id, Report report);
    Task<Boolean> deleteReport(int id);
}