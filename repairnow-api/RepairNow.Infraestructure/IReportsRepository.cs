namespace RepairNow.Infraestructure;

public interface IReportsRepository
{
    List<Report> getAll();
    Report getReportById(int id);
    Task<Boolean> createReport(string name);
    Boolean updateReport(int id, string name);
    Boolean deleteReport(int id);
}
