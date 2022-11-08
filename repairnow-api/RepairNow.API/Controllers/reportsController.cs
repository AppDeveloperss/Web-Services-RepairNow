

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepairNow.Domain;
using RepairNow.Infraestructure;
using RepairNowAPI.Resources;

namespace RepairNowAPI.Controllers
{
    [Route("api/reports")]
    [ApiController]
    
    public class ReportsController:ControllerBase
    {
        private IReportsDomain _reportsDomain;
        private IMapper _mapper;
        
        public ReportsController(IReportsDomain reportsDomain, IMapper _mapper)
        {
            _reportsDomain = reportsDomain;
            this._mapper=_mapper;
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
        public async Task<Boolean> Post([FromBody] ReportResource reportResource)
        {
            var user = _mapper.Map<ReportResource, Report>(reportResource);
            string xd = "aea";
            var result = await _reportsDomain.createReport(xd);
            return result;
        }
        
        // PUT: api/reports/5
        [HttpPut("{id}")]
        public Boolean Put(int id, [FromBody] string value)
        {
            var result = _reportsDomain.updateReport(id, value);
            return result;
        }
        
        
        // DELETE: api/reports/5
        [HttpDelete("{id}")]
        public Boolean Delete(int id)
        {
            var result = _reportsDomain.deleteReport(id);
            return result;
        }

    }
    

}

