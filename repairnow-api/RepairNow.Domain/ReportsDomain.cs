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

    public async Task<bool> createReport(Report report)
    {
        return await _reportsRepository.createReport(report);
    }

    public async Task<bool> updateReport(int id, Report report)
    {
        return await _reportsRepository.updateReport(id, report);
    }

    public async Task<bool> deleteReport(int id)
    {
        return await _reportsRepository.deleteReport(id);
    }
}