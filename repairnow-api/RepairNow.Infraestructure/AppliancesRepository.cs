using RepairNow.Infraestructure.Context;

namespace RepairNow.Infraestructure;

public class AppliancesRepository:IAppliancesRepository
{
    
    private RepairNowDB _repairNowDb;
    public AppliancesRepository(RepairNowDB repairNowDb)
    {
        _repairNowDb = repairNowDb;
    }
    
    public List<Appliance> getAll()
    {
        return _repairNowDb.Appliances.Where(appliance=>appliance.isActive).ToList(); 
    }

    public Appliance getApplianceById(int id)
    {
        return _repairNowDb.Appliances.Find(id);
        //Single or default devuelve solo un elemento mientras que el ToList devuelve una lista
        //  return _repairNowDb.Users
        //    .Include(user => user.Tutorials)
        //    .SingleOrDefault(user=>user.id==id)
    }

    public async Task<bool> createAppliance(string name)
    {
        Appliance appliance = new Appliance();
        appliance.name = name;
        
        _repairNowDb.Database.BeginTransactionAsync();
        try
        {
            _repairNowDb.Appliances.AddAsync(appliance);
            _repairNowDb.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _repairNowDb.Database.RollbackTransactionAsync();//Si pasa algo malo entonces lo anula(hace rollback)
        }
        _repairNowDb.Database.CommitTransactionAsync(); //Si no pasa algo malo entonces good
        return true;
    }

    public bool updateAppliance(int id, string name)
    {
        throw new NotImplementedException();
    }

    public bool deleteAppliance(int id)
    {
        throw new NotImplementedException();
    }
}