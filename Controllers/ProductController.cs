
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using sitesampleproject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sitesampleproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // private readonly ProductContext _context;

        // public ProductController(ProductContext context){
        //     _context = context;
        // }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        // {
        //     return await _context.Product.ToListAsync();
        // }

        // // GET: api/Movies/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Product>> GetProduct(Guid id)
        // {
        //     var product = await _context.Product.FindAsync(id);

        //     if (product == null)
        //     {
        //         return NotFound();
        //     }

        //     return product;
        // }

        




    }
}