using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepairNow.Domain;
using RepairNow.Infraestructure;
using RepairNowAPI.Resources;

namespace RepairNowAPI.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    
    public class AppointmentsController:ControllerBase
    {
        private IAppointmentsDomain _appointmentsDomain;
        private IMapper _mapper;
        
        public AppointmentsController(IAppointmentsDomain appliancesDomain, IMapper _mapper)
        {
            _appointmentsDomain = appliancesDomain;
            this._mapper=_mapper;
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
        
        // POST: api/appointments
        [HttpPost]
        public async Task<Boolean> Post([FromBody] AppointmentResource appointmentResource)
        {
            var user = _mapper.Map<AppointmentResource, Appointment>(appointmentResource);
            string xd = "aea";
            var result = await _appointmentsDomain.createAppointment(xd);
            return result;
        }
        
        // PUT: api/appointments/5
        [HttpPut("{id}")]
        public Boolean Put(int id, [FromBody] string value)
        {
            var result = _appointmentsDomain.updateAppointment(id, value);
            return result;
        }
        
        
        // DELETE: api/appointments/5
        [HttpDelete("{id}")]
        public Boolean Delete(int id)
        {
            var result = _appointmentsDomain.deleteAppointment(id);
            return result;
        }

    }
    

}

