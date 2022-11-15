using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepairNow.Domain;
using RepairNow.Infraestructure;
using RepairNowAPI.Resources;

namespace RepairNowAPI.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    
    public class AppointmentsController:ControllerBase
    {
        private IAppointmentsDomain _appointmentsDomain;
        private IMapper _mapper;

        public AppointmentsController(IAppointmentsDomain appliancesDomain, IMapper mapper)
        {
            _appointmentsDomain = appliancesDomain;
            _mapper=mapper;
        }
        
        // GET: api/appointments
        [HttpGet]
        public IEnumerable<Appointment> Get()
        {
            return _appointmentsDomain.getAll();
        }
        
        // GET: api/appointments/5
        [HttpGet("{id}")]
        public Appointment Get(int id)
        {
            return _appointmentsDomain.getAppointmentById(id);
        }
        
        
        //[HttpPost]
        //[ProducesResponseType(typeof(IActionResult),201)]
        //public async Task<IActionResult> Post([FromBody] ApplianceResource applianceInput)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid) return BadRequest("Error de Formato");
        //        var appliance = _mapper.Map<ApplianceResource, Appliance>(applianceInput);
        //        var result = await _appliancesDomain.createAppliance(appliance);
//
        //        return StatusCode(StatusCodes.Status201Created, "Appliance Creado");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        //    }
        //}
        // POST: api/appointments
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult),201)]
        public async Task<IActionResult> Post([FromBody] AppointmentResource appointmentInput)
        {
            
            try
            {
                if (!ModelState.IsValid) return BadRequest("Error de Formato");
                var appointment = _mapper.Map<AppointmentResource, Appointment>(appointmentInput);
                var result = await _appointmentsDomain.createAppointment(appointment);
            
                return StatusCode(StatusCodes.Status201Created, "Appointment Creado");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            
        }
        
        // PUT: api/appointments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AppointmentResource appointmentInput)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Error de Formato");
                }
            
                var appointment = _mapper.Map<AppointmentResource, Appointment>(appointmentInput);
                var result = _appointmentsDomain.updateAppointment(id, appointment);
                appointment.id = id;
                return StatusCode(StatusCodes.Status200OK,"Usuario Actualizado");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error al procesar");
            }
        }
        
        
        // DELETE: api/appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Error de Formato");
                }
            
                var result = await _appointmentsDomain.deleteAppointment(id);
                return StatusCode(StatusCodes.Status200OK,"Usuario Eliminado Satisfactoriamente");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error al procesar");
            }
        }

    }
    

}

