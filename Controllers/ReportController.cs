
using Microsoft.AspNetCore.Mvc;
using sitesampleproject.Models;
using sitesampleproject.Services;

namespace sitesampleproject.Controllers;
[ApiController]
[Route("api/")]
    public class ReportController : ControllerBase{
    ReportService _service;
    public ReportController(ReportService service){
        _service = service;
    }

    [HttpGet("getreport/{userid}")]
    public IEnumerable<SaleRecord> GetReport(string userid, [FromBody] DateTime startDate, DateTime endDate){
        Guid parseduserid = Guid.Parse(userid);
        return _service.GetAllReports(parseduserid, startDate, endDate);

    }

}