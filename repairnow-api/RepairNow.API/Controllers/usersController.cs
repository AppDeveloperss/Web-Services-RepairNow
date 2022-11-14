using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
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
    [Produces(MediaTypeNames.Application.Json)]

    public class usersController : ControllerBase
    {
        private IUsersDomain _usersDomain;
        private IMapper _mapper;
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
        [ProducesResponseType(typeof(IActionResult),201)]
        public async Task<IActionResult> Post([FromBody] UserResource userInput)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Error de Formato");
                }
            
                var user = _mapper.Map<UserResource, User>(userInput);
                var result = await _usersDomain.createUser(user);
            
                return StatusCode(StatusCodes.Status201Created,"Usuario Creado");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error al procesar");
            }

        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserResource userInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Error de Formato");
                }
            
                var user = _mapper.Map<UserResource, User>(userInput);
                user.id = id;
                var result = await _usersDomain.updateUser(id, user);
                return StatusCode(StatusCodes.Status200OK,"Usuario Actualizado");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error al procesar");
            }
            

        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Error de Formato");
                }
                
                var result = await _usersDomain.deleteUser(id);
                return StatusCode(StatusCodes.Status200OK,"Usuario Actualizado");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error al procesar");
            }
        }
    };
}
