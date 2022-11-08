using RepairNow.Infraestructure;

namespace RepairNow.Domain;

public class ReportsDomain:IReportsDomain
{
    private IReportsRepository _reportsRepository;

    public ReportsDomain(IReportsRepository reportsRepository)
    {
        _reportsRepository = reportsRepository;
    }

    public List<Report> getAll()
    {
        return _reportsRepository.getAll();
    }

    public Report getReportById(int id)
    {
        return _reportsRepository.getReportById(id);
    }

    public Task<bool> createReport(string name)
    {
        return _reportsRepository.createReport(name);
    }

    public bool updateReport(int id, string name)
    {
        return _reportsRepository.updateReport(id, name);
    }

    public bool deleteReport(int id)
    {
        return _reportsRepository.deleteReport(id);
    }
}