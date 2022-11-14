using Microsoft.EntityFrameworkCore;
using RepairNow.Infraestructure.Context;

namespace RepairNow.Infraestructure;

//Aquí vamos a hacer la conexión a la base de datos 
public class UsersRepository:IUsersRepository
{
    //Para empezar la conexion vamos a necesitar el glorioso DB context
    private RepairNowDB _repairNowDb;
    public UsersRepository(RepairNowDB repairNowDb)
    {
        _repairNowDb = repairNowDb;
    }
    public List<User> getAll()
    {
        //To List sirve para devolver una lista de este objeto LINQ con WHERE FILTRAMOS 
        return _repairNowDb.Users.Where(user=>user.isActive).ToList(); 
        
        //En el caso de tener algo asociado con la base de datos relacional
        //return _repairNowDb.Users
        //    .Include(user=>user.Tutorials)
        //    .Where(user=>user.isActive)
        //    .ToList()
        
        //Por si queremos filtrar por nombres
        //var filterByName = "category";
        //return _repairNowDb.Users
        //    .Include(user=>user.Tutorials)
        //    .Where(user=>user.isActive && user.firsName.Contains(filterByName)) &&= AND
        //    .ToList()
        
        //JOINS
        //var resul=from user in _repairNowDb.Users
        //    join tutorials in _repairNowDb on user.id equals tutorials.id
        //    join user in _repairNowDb.Users on 

    }

    public User getUserById(int id)
    {
        return _repairNowDb.Users.Find(id);

        //Single or default devuelve solo un elemento mientras que el ToList devuelve una lista
        //  return _repairNowDb.Users
        //    .Include(user => user.Tutorials)
        //    .SingleOrDefault(user=>user.id==id)
    }

    public async Task<bool> createUser(User user)
    {
        //User user = new User();
        //user.firstName = name;
        
        
        //TRANSACCION solo para insert, updated, delete , para lectura no hay transacciones
        using (var trasacction = _repairNowDb.Database.BeginTransactionAsync())
        {
            try
            {
                _repairNowDb.Users.AddAsync(user);
                _repairNowDb.SaveChanges();
            }
            catch (Exception ex)
            {
                _repairNowDb.Database.RollbackTransactionAsync();//Si pasa algo malo entonces lo anula(hace rollback)
            }
        }
        
        _repairNowDb.Database.CommitTransactionAsync(); //Si no pasa algo malo entonces good
        return true;
    }

    public bool updateUser(int id, string name)
    {
        User user = _repairNowDb.Users.Find(id);

        user.firstName = name;
        user.DateUpdate=DateTime.Now;
        
        _repairNowDb.Users.Update(user);
        _repairNowDb.SaveChanges();

        return true;

    }

    public bool deleteUser(int id)
    {
        User user = _repairNowDb.Users.Find(id);

        //_repairNowDb.Users.Remove(user);
        //_repairNowDb.SaveChanges();

        user.isActive = false;
        user.DateUpdate=DateTime.Now;
        _repairNowDb.Users.Update(user);
        _repairNowDb.SaveChanges();
        return true;
        
    }
}