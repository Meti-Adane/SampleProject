
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sitesampleproject.Models;
using sitesampleproject.Services;

namespace sitesampleproject.Controllers{
    [Route("api/[controller]/")]
    [ApiController]
    [Authorize]
    public class SalesController : ControllerBase{
        SalesService _service;
        ProductService _productService;

        public SalesController (SalesService service, ProductService productService){
            _service = service;
            _productService = productService;
        }


        // Plan routes 
        [HttpGet("sale/{userid}/plan")]
        public  IEnumerable<Plan> GetSalePlans(string userid)
        {
            Guid paresedUserId = Guid.Parse(userid);
            var plans =  _service.GetAllPlans(paresedUserId);
            return plans;
        }
        [HttpGet("sale/{userid}/plan/{planid}")]
        public async Task<ActionResult<IEnumerable<Plan>>> GetPlanById(string userid, string recordId)
        {
            Guid paresedUserId = Guid.Parse(userid);
            Guid paresedRecordId = Guid.Parse(recordId);
            var plan = _service.GetPlanById(paresedUserId, paresedRecordId);

            if (plan == null)
            {
                return NotFound();
            }

            return Ok(plan);
        }
        [HttpPost("sale/{userid}/plan/{title}/{content}")]

        public async Task<ActionResult<IEnumerable<Plan>>> CreatePlan(String userid, string title, string content)
        {
            Guid parsedId = Guid.Parse(userid);
            Plan newplan = new Plan();
            newplan.Id = Guid.NewGuid();
            newplan.Title = title;
            newplan.Content = content;
            newplan.Author.Id = parsedId;
            
            var createdPlan = _service.CreatePlan(newplan);
            if (createdPlan is not null ){
                string uri = ("sale/"+userid+"/plan/"+ (newplan.Id).ToString());
                return Created(uri, createdPlan);
            }
            return StatusCode(500);

        }

        [HttpDelete("sale/{userid}/plan/{id}")]
        public async Task<ActionResult<IEnumerable<Plan>>> DeletePlan(String id)
        {
            Guid parsedid = Guid.Parse(id);
    {
            bool isDeleted = _service.DeletePlan(parsedid);

            if(isDeleted)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        }
        


        // Sale routes
        [HttpGet("sale/{userid}/record/{recordid}")]
    
        public async Task<ActionResult<IEnumerable<SaleRecord>>> GetSaleRecordById(string userid, string recordId)
        {
            Guid paresedUserId = Guid.Parse(userid);
            Guid paresedRecordId = Guid.Parse(recordId);
            var record = _service.GetRecordById(paresedUserId, paresedRecordId);

            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }        

        [HttpGet("sale/{userid}/record")]
        
        public  IEnumerable<SaleRecord> GetSaleRecords(string userid)
        {
            Guid paresedUserId = Guid.Parse(userid);
            var records =  _service.GetAllRecords(paresedUserId);
            return records;
        }

        [HttpPost("sale/{userid}/record/")]

        public async Task<ActionResult<IEnumerable<SaleRecord>>> CreateSaleRecord(string userid, [FromBody] SaleRecord record)
        {
            Guid parsedId = Guid.Parse(userid);
            SalesPerson user = _service.GetSalesPersonById(parsedId);
            if (user is null) {
                return StatusCode(400);
            }

            SaleRecord newrecord = new SaleRecord();
            Unit immidiateUnit = user.Unit;
            Branch immidiateBranch =  immidiateUnit.Branch;
            double unitprice = _productService.GetUnitPrice();
            newrecord.Id = Guid.NewGuid();
            newrecord.Author.Id = parsedId;
            newrecord.Branch.Id = immidiateBranch.Id;
            newrecord.Unit.Id = immidiateUnit.Id;
            newrecord.TotalSalePrice = record.NumberOfItemSold * unitprice;
            newrecord.NumberOfItemSold = record.NumberOfItemSold;
            newrecord.NumberAccquiredCustomers = record.NumberAccquiredCustomers;
            newrecord.CreatedAt = DateTime.Now;

            var createdPlan = _service.CreateRecord(newrecord);
            if (createdPlan is not null ){
                string uri = ("sale/"+userid+"/record/"+ (newrecord.Id).ToString());
                return Created(uri, createdPlan);
            }
            return StatusCode(500);
        }

        [HttpDelete("sale/{userid}/record/{recordid}")]
        public async Task<ActionResult<IEnumerable<SaleRecord>>> DeleteSaleRecord(string id)
        {
            Guid parsedid = Guid.Parse(id);
            bool isDeleted = _service.DeleteRecord(parsedid);
            if(isDeleted)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}