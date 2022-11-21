

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairNow.Domain;
using RepairNow.Infraestructure;
using RepairNowAPI.Resources;

namespace RepairNowAPI.Controllers
{
    [Authorize]
    [Route("api/reports")]
    [ApiController]
    
    public class ReportsController:ControllerBase
    {
        private IReportsDomain _reportsDomain;
        private IMapper _mapper;
        
        public ReportsController(IReportsDomain reportsDomain, IMapper mapper)
        {
            _reportsDomain = reportsDomain;
            _mapper=mapper;
        }
        
        // GET: api/reports
        [HttpGet]
        public IEnumerable<Report> Get()
        {
            return _reportsDomain.getAll();
        }
        
        // GET: api/reports/5
        [HttpGet("{id}")]
        public Report Get(int id)
        {
            return _reportsDomain.getReportById(id);
        }
        
        // POST: api/reports
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReportResource reportInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Error de Formato");
                }
            
                var report = _mapper.Map<ReportResource, Report>(reportInput);
                var result = await _reportsDomain.createReport(report);
            
                return StatusCode(StatusCodes.Status201Created,"Reporte Creado");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error al procesar");
            }
        }
        
        // PUT: api/reports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ReportResource reportInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Error de Formato");
                }
            
                var report = _mapper.Map<ReportResource, Report>(reportInput);
                report.id = id;
                var result = await _reportsDomain.updateReport(id, report);
                return StatusCode(StatusCodes.Status200OK,"Reporte Actualizado");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error al procesar");
            }
        }
        
        
        // DELETE: api/reports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Error de Formato");
                }
            
                var result = await _reportsDomain.deleteReport(id);
                return StatusCode(StatusCodes.Status200OK,"Reporte Eliminado Satisfactoriamente");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error al procesar");
            }
        }

    }
    

}

