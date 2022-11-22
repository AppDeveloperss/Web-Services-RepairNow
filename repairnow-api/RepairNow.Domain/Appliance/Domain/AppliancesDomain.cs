using System.Security;
using System.Text.RegularExpressions;
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

    public async Task<bool> createAppliance(Appliance appliance)
    {
        if (Regex.IsMatch(appliance.name, @"^[0-9]+$"))
        {
            throw new VerificationException("Invalid Name Format");
        }
        
        if (appliance.year>2022)
        {
            throw new VerificationException("Invalid Date Year");
        }
        
        return await _appliancesRepository.createAppliance(appliance);
    }

    public async Task<bool> updateAppliance(int id, Appliance appliance)
    {
        if (Regex.IsMatch(appliance.name, @"^[0-9]+$"))
        {
            throw new VerificationException("Invalid Name Format");
        }
        
        if (appliance.year>2022)
        {
            throw new VerificationException("Invalid Date Year");
        }
        
        return await _appliancesRepository.updateAppliance(id, appliance);
    }

    public async Task<bool> deleteAppliance(int id)
    {
        return await _appliancesRepository.deleteAppliance(id);
    }
}