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
        //return _repairNowDb.Users.Find(id);
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
        using (var transacction = _repairNowDb.Database.BeginTransactionAsync())
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

    public async Task<bool> updateUser(int id, User user_new)
    {
        //User user = new User();
        //user.firstName = name;
        
        
        //TRANSACCION solo para insert, updated, delete , para lectura no hay transacciones
        using (var transacction = _repairNowDb.Database.BeginTransactionAsync())
        {
            try
            {
               //User user = _repairNowDb.Users.Find(id);
               User user=await _repairNowDb.Users.FindAsync(id);
               
               user.DateUpdate=DateTime.Now;
               user.firstName = user_new.firstName;
               user.lastName = user_new.lastName;
               user.email = user_new.email;
               user.password = user_new.password;
               user.phone = user_new.phone;
               user.plan = user_new.plan;
               user.address = user_new.address;
               
               _repairNowDb.Users.Update(user);
               _repairNowDb.SaveChanges();
               //await transacction.CommitAsync();
            }
            catch (Exception ex)
            {
                _repairNowDb.Database.RollbackTransactionAsync();//Si pasa algo malo entonces lo anula(hace rollback)
            }
        }
        
        _repairNowDb.Database.CommitTransactionAsync(); //Si no pasa algo malo entonces good
        return true;
        
        //var strategy = _repairNowDb.Database.CreateExecutionStrategy();
        //
        //await strategy.ExecuteAsync(async () =>
        //{
        //    await using (var transacction = await _repairNowDb.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            //User user = _repairNowDb.Users.Find(id);
        //            User user=await _repairNowDb.Users.FindAsync(id);
        //            
        //            user.DateUpdate=DateTime.Now;
        //            user.firstName = user_new.firstName;
        //            user.lastName = user_new.lastName;
        //            user.email = user_new.email;
        //            user.password = user_new.password;
        //            user.phone = user_new.phone;
        //            user.plan = user_new.plan;
        //            user.address = user_new.address;
        //            
        //            _repairNowDb.Users.Update(user);
        //            await _repairNowDb.SaveChangesAsync();
        //            await transacction.CommitAsync();
        //        }
        //        catch(Exception ex)
        //        {
        //            await _repairNowDb.Database.RollbackTransactionAsync();//Si pasa algo malo entonces lo anula(hace rollback)
        //        }
        //    }
        //});
        //
        //_repairNowDb.Database.CommitTransactionAsync(); //Si no pasa algo malo entonces good
        //return true;
    }

    public async Task<bool> deleteUser(int id)
    {
        
        using (var transacction = _repairNowDb.Database.BeginTransactionAsync())
        {
            try
            {
                User user = await _repairNowDb.Users.FindAsync(id);
                user.isActive = false;
                user.DateUpdate=DateTime.Now;
                _repairNowDb.Users.Update(user);
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