using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using NuGet.Protocol;
using Microsoft.AspNetCore.Mvc;
using RepairNow.Domain;
using RepairNow.Infraestructure;
using RepairNowAPI.Resources;

namespace RepairNowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class usersController : ControllerBase
    {
        //Instanciamos una variable en la interfaz
        private IUsersDomain _usersDomain;

        private IMapper _mapper;
        //luego en el constructor de esta clase le pasamos ese parametro
        public usersController(IUsersDomain usersDomain, IMapper mapper)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
        }
        
        // GET: api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _usersDomain.getAll();
        }

        // GET: api/users/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return _usersDomain.getUserById(id);
        }

        // POST: api/users
        [HttpPost]
        public async Task<Boolean> Post([FromBody] UserResource userInput)
        {
            //var user = new User()
            //{
            //    firstName = userInput.firstName,
            //    lastName = userInput.lastName,
            //    email = userInput.email,
            //    password = userInput.password,
            //    address = userInput.address,
            //    phone = userInput.phone,
            //    type = userInput.type,
            //    plan = userInput.plan
            //};

            var user = _mapper.Map<UserResource, User>(userInput);
            string xd = "aea";
            var result = await _usersDomain.createUser(xd);
            return result;
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public Boolean Put(int id, [FromBody] string value)
        {
            var result = _usersDomain.updateUser(id, value);
            return result;
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public Boolean Delete(int id)
        {
            var result = _usersDomain.deleteUser(id);
            return result;
        }
    };
}
