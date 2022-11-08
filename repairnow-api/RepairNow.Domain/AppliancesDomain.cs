using RepairNow.Infraestructure;

namespace RepairNow.Domain;

public class AppliancesDomain:IAppliancesDomain
{
    private IAppliancesRepository _appliancesRepository;

    public AppliancesDomain(IAppliancesRepository appliancesRepository)
    {
        _appliancesRepository = appliancesRepository;
    }
    
    public List<Appliance> getAll()
    {

        return _appliancesRepository.getAll();
    }

    public Appliance getApplianceById(int id)
    {
        return _appliancesRepository.getApplianceById(id);
    }

    public Task<bool> createAppliance(string name)
    {
        return _appliancesRepository.createAppliance(name);
    }

    public bool updateAppliance(int id, string name)
    {
        return _appliancesRepository.updateAppliance(id, name);
    }

    public bool deleteAppliance(int id)
    {
        return _appliancesRepository.deleteAppliance(id);
    }
}