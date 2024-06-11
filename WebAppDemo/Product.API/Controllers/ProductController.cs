using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Respository;
using ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CatalogContext _catalogContext;

        public ProductController(CatalogContext context)
        {
            _catalogContext = context ?? throw new ArgumentNullException(nameof(context));

        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetProducts()

        {

            var itemsOnPage = await _catalogContext.CatalogItems
                .OrderBy(c => c.product_name)
                 .ToListAsync();

            return Ok(itemsOnPage);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> SearchProduct([FromQuery] string productName)

        {
            var res = await _catalogContext.CatalogItems
                     .Where(p => p.product_name == productName)
                     .Select(p => p).ToListAsync();

            return Ok(res);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Models.Product product)
        {
           
            _catalogContext.CatalogItems.Add(product);
            var res = await _catalogContext.SaveChangesAsync();
            if(res == 1)            
                return Ok();
            
            return BadRequest();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct([FromBody] Models.Product product)
        {

            _catalogContext.CatalogItems.Update(product);
            var res = await _catalogContext.SaveChangesAsync();
            if (res == 1)
                return Ok();

            return BadRequest();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> DeleteProduct([FromBody] Models.Product product)
        {
            _catalogContext.CatalogItems.Remove(product);
            var res = await _catalogContext.SaveChangesAsync();
            if (res == 1)
                return Ok();

            return BadRequest();
        }
    }
}
