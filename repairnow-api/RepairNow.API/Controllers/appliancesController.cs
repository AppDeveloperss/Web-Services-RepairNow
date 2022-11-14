using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepairNow.Domain;
using RepairNow.Infraestructure;
using RepairNowAPI.Resources;

namespace RepairNowAPI.Controllers
{
    [Route("api/appliances")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class AppliancesController:ControllerBase
    {
        private IAppliancesDomain _appliancesDomain;
        private IMapper _mapper;
        
        public AppliancesController(IAppliancesDomain appliancesDomain, IMapper _mapper)
        {
            _appliancesDomain = appliancesDomain;
            this._mapper=_mapper;
        }
        
        // GET: api/appliances
        [HttpGet]
        public IEnumerable<Appliance> Get()
        {
            return _appliancesDomain.getAll();
        }
        
        // GET: api/appliances/5
        [HttpGet("{id}")]
        public Appliance Get(int id)
        {
            return _appliancesDomain.getApplianceById(id);
        }
        
        // POST: api/appliances
        [HttpPost]
        public async Task<Boolean> Post([FromBody] ApplianceResource applianceInput)
        {
            var user = _mapper.Map<ApplianceResource, Appliance>(applianceInput);
            string xd = "aea";
            var result = await _appliancesDomain.createAppliance(xd);
            return result;
        }
        
        // PUT: api/appliances/5
        [HttpPut("{id}")]
        public Boolean Put(int id, [FromBody] string value)
        {
            var result = _appliancesDomain.updateAppliance(id, value);
            return result;
        }
        
        
        // DELETE: api/appliances/5
        [HttpDelete("{id}")]
        public Boolean Delete(int id)
        {
            var result = _appliancesDomain.deleteAppliance(id);
            return result;
        }
        
        
        
    }
}