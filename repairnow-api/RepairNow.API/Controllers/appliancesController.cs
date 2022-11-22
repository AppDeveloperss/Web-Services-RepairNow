using System.Net.Mime;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepairNow.Domain;
using RepairNow.Infraestructure;
using RepairNowAPI.Resources;
using RepairNowAPI.Filter;


namespace RepairNowAPI.Controllers;

[Authorize]
[Route("api/appliances")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class AppliancesController:ControllerBase{

    private IAppliancesDomain _appliancesDomain;
    private IMapper _mapper;
        
    public AppliancesController(IAppliancesDomain appliancesDomain, IMapper mapper)
    {
        _appliancesDomain = appliancesDomain;
        _mapper=mapper;
    }
        

    // GET: api/appliances

    [HttpGet]
    [Authorize("customer")]
    public IEnumerable<Appliance> Get()
    {
        return _appliancesDomain.getAll();
    }
        

    // GET: api/appliances/5
    [HttpGet("{id}")]
    [Authorize("customer")]
    public Appliance Get(int id)
    {
        return _appliancesDomain.getApplianceById(id);
    }
        


    // POST: api/appliances
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult),201)]
    [Authorize("customer")]
    public async Task<IActionResult> Post([FromBody] ApplianceResource applianceInput)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest("Error de Formato");
            var appliance = _mapper.Map<ApplianceResource, Appliance>(applianceInput);
            var result = await _appliancesDomain.createAppliance(appliance);

            return StatusCode(StatusCodes.Status201Created, "Appliance Creado");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }
    }
        
        

    // PUT: api/appliances/5
    [HttpPut("{id}")]
    [Authorize("customer")]

    public async Task<IActionResult> Put(int id, [FromBody] ApplianceResource applianceInput)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Formato");
            }

            var appliance = _mapper.Map<ApplianceResource, Appliance>(applianceInput);
            appliance.id = id;
            var result = _appliancesDomain.updateAppliance(id, appliance);
            return StatusCode(StatusCodes.Status200OK,"Appliance Actualizado");
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,"Error al procesar");
        }
    }
        
        

    // DELETE: api/appliances/5
    [HttpDelete("{id}")]
    [Authorize("customer")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Formato");
            }
            
            var result = await _appliancesDomain.deleteAppliance(id);
            return StatusCode(StatusCodes.Status200OK,"Appliance Eliminado Satisfactoriamente");
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,"Error al procesar");
        }
            
    }

}